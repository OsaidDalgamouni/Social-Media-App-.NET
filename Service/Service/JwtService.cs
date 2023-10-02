using Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Service.DTO;
using Service.IService;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class JwtService : IAuthenticationService
    {
        private readonly SymmetricSecurityKey _key;
       
        public JwtService(IConfiguration configuration)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])); 
        }
        public string CreateJWT(User user )
        {
            var cliams = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId,user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName,user.Username)

            };
            var creds= new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(cliams),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token=tokenHandler.CreateToken(tokenDescriptor);
            return  tokenHandler.WriteToken(token);

               
            


            /* var jwtExpireDays = DateTime.UtcNow.AddDays(7);
             var tokenHandler = new JwtSecurityTokenHandler();
             var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
             //var loginObject = JsonConvert.SerializeObject(loginDTO);
             var tokenDescriptor = new SecurityTokenDescriptor
             {
                 Subject = new ClaimsIdentity(new Claim[]
                 {
                              new Claim(JwtRegisteredClaimNames.NameId,user.Username),
                              //new Claim(ClaimTypes.NameIdentifier,User.Email.ToString()),
                              //new Claim(ClaimTypes.NameIdentifier,User.Password.ToString()),
                 }),
                 Expires = jwtExpireDays,
                 SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256)
             };
             var token = tokenHandler.CreateToken(tokenDescriptor);
             var userToken = tokenHandler.WriteToken(token);

             return userToken;*/
        }

        //DateTime expiration = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["Jwt:EXPIRATION_MINUTES"]));
        //Claim[] claims = new Claim[]
        //{
        //            new Claim(JwtRegisteredClaimNames.Sub,User.Userid.ToString()),
        //            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()), //generate jwt id
        //             new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()),//issued date of token
        //             new Claim(ClaimTypes.NameIdentifier,User.Email.ToString()),
        //              new Claim(ClaimTypes.NameIdentifier,User.Password.ToString()),
        //};
        //SymmetricSecurityKey securityKey = new SymmetricSecurityKey(
        //   Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])
        //    );
        //SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        //JwtSecurityToken tokenGenerator = new JwtSecurityToken(_configuration["Jwt:Issure"], _configuration["Jwt:Audience"], claims, expires: expiration, signingCredentials: signingCredentials);
        //JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        //string token = jwtSecurityTokenHandler.WriteToken(tokenGenerator);
        //return new Authentication() { Token = token, Email = User.Email, Username = User.Username, Expiration = expiration };
    }
}
