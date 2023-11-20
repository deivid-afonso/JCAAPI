using JCAApi.Converter;
using JCAApi.Data;
using JCAApi.Dto;
using JCAApi.Models;
using System;

namespace JCAApi.Services
{
    public class UserService
    {
        private readonly ApiDbContext _context;
        private readonly UserConverter _converter;

        public UserService(ApiDbContext context, UserConverter converter)
        {
            _context = context;
            _converter = converter;
        }

        public void UpdateUser(UserDto user)
        {
            UserModel? existinguser = verifyUser(user);
            _converter.ConvertToUser(user);
            _context.SaveChanges();
        }

        public UserModel GetuserById(int id)
        {
            verifyUserById(id);
            return _context.User.Find(id);
        }

        public void Adduser(UserDto user)
        {
            try
            {
                UserModel? userModel = _converter.ConvertToUser(user);
                _context.User.Add(userModel);
                _context.SaveChanges();
            }
            catch (InvalidOperationException e)
            {
                throw e;
            }
        }

        public void DeleteUser(int id)
        {
            verifyUserById(id);

            _context.User.Remove(_context.User.Find(id));
            _context.SaveChanges();
        }


        private UserModel verifyUser(UserDto user)
        {
            var existingUser = _context.User.Find(user.UserId);
            if (existingUser == null)
            {
                throw new InvalidOperationException($"user com ID {user.UserId} não encontrado.");
            }

            return existingUser;
        }

        private UserModel verifyUserById(int id)
        {
            var existinguser = _context.User.Find(id);
            if (existinguser == null)
            {
                throw new InvalidOperationException($"user com ID {existinguser.UserId} não encontrado.");
            }

            return existinguser;
        }

        //    public UserModel Authenticate(string username, string password)
        //    {
        //        var user = _context.User.FirstOrDefault(u => u.Username == username && u.Password == password);

        //    }
        //}
    }
}