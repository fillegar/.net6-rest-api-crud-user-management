using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using User.Core;
using User.Core.Model;
using User.Service;

namespace User.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserInfoService userInfoService;
        private readonly IConfiguration configuration;
        public LoginController(UserInfoService userInfoService, IConfiguration configuration)
        {
            this.userInfoService = userInfoService;
            this.configuration = configuration;
        }
        [HttpPost]
        public Token Login([FromForm] UserLogin userLogin)
        {
            UserInfo user =  userInfoService.getUserInfoByEmail(userLogin.Email);
            if (user != null)
            {
                var token = createAccessToken(user);

                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenEndDate = token.Expiration.AddMinutes(3);

                userInfoService.updateUserInfo(user);

                return token;
            }
            return null;
        }

        private Token createAccessToken(UserInfo user)
        {
            Token tokenInstance = new Token();
            var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, "Subject"),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim(ClaimTypes.Role, user.Role),
                        new Claim("DisplayName", user.FullName),
                        new Claim("Email", user.Email)
                    };

            tokenInstance.Expiration = DateTime.Now.AddMinutes(10);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                expires: tokenInstance.Expiration,
                signingCredentials: signIn);

            tokenInstance.AccessToken = new JwtSecurityTokenHandler().WriteToken(token);

            //create refreshToken
            byte[] number = new byte[32];
            using (RandomNumberGenerator random = RandomNumberGenerator.Create())
            {
                random.GetBytes(number);
                tokenInstance.RefreshToken = Convert.ToBase64String(number);
            }

            return tokenInstance;
        }
    }
}
