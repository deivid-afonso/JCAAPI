using Microsoft.AspNetCore.Mvc;
using JCAApi.Data;
using JCAApi.Dto;
using JCAApi.Services;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JCAApi.Models;

namespace JCAApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApiDbContext _context;
        private readonly UserService _userService;
        private readonly IConfiguration _configuration;

        public UserController(ApiDbContext context, UserService userService, IConfiguration configuration)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

        }

        [HttpPost("login")]
        public IActionResult Login(LoginModel model)
        {
            var user = _userService.Authenticate(model.Username, model.Password);
            if (user == null)
            {
                return Unauthorized();
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("test123");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new { Token = tokenString });
        }



        [HttpGet(Name = "Get all users")]
        public IActionResult GetAllusers()
        {
            return Ok(_context.User.ToList());
        }

        [HttpGet("{id}", Name = "Find user by id")]
        public IActionResult FindById(int id)
        {
            var user = _userService.GetuserById(id);

            return Ok(user);
        }

        [HttpPut(Name = "Insert new user")]
        public IActionResult Put([FromBody] UserDto user)
        {

            try
            {
                _userService.Adduser(user);

                return Ok("user cadastrado com sucesso");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar os dados");
            }
        }

        [HttpPost(Name = "Update user")]
        public IActionResult Update([FromBody] UserDto user)
        {
            _userService.UpdateUser(user);

            return Ok("user atualizado com sucesso");
        }

        [HttpDelete("{id}", Name = "Delete user by id")]
        public IActionResult Delete(int id)
        {
            _userService.DeleteUser(id);

            return Ok("user deletado com sucesso!");
        }
    }
}
