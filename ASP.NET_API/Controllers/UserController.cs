using ASP.NET_API.Model;
using ASP.NET_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ASP.NET_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository _userRepository;
        private readonly AppSetting _appSettings;
        public UserController(IUserRepository userRepository, IOptionsMonitor<AppSetting> appSettingsMonitor)
        {

            _userRepository = userRepository;
            _appSettings = appSettingsMonitor.CurrentValue;
        }
        [HttpPost("Login")]
        public IActionResult Validate(LoginModel model)
        {
            var user = _userRepository.Validate(model);
            if (user == null)
            {
                return Ok(new
                {
                    Success = false,
                    Message = "Invalid username or password"
                });
            }
         
            return Ok(new
            {
                Success = true,
                Message = "Authenticate success",
                Data = GenerateToken(user)
            });
        }
        private string GenerateToken(NguoiDung nguoidung)
        {
            var jwrTokenHandler = new JwtSecurityTokenHandler();
            
            var secretKeyBytes = Encoding.UTF8.GetBytes(_appSettings.SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, nguoidung.UserName),
                    new Claim(ClaimTypes.Email, nguoidung.Email),
                    new Claim("TokenId", Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = jwrTokenHandler.CreateToken(tokenDescriptor);
           
            return jwrTokenHandler.WriteToken(token);

        }
    }
}
