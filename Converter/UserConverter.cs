using JCAApi.Dto;
using JCAApi.Models;

namespace JCAApi.Converter
{
    public class UserConverter
    {
        public UserModel? ConvertToUser(UserDto user)
        {

            var newUser = new UserModel
            {
                Nome = user.Nome,
                Email = user.Email,
                Ativo = user.Ativo,
                Permissao = user.Permissao
            };

            return newUser;
        }

    }

    
}
