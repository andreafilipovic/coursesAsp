using Courses.EfDataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Api.Core
{
    public class JwtManager
    {
        private readonly CoursesContext _context;

        public JwtManager(CoursesContext context)
        {
            _context = context;
        }

        public string MakeToken(string username, string password)
        {
            // var pass = _context.Users.Select(u => u.Password);
            //var md5 = new MD5CryptoServiceProvider().ComputeHash(password);
           // var md5pass = EasyEncryption.MD5.ComputeMD5Hash(password);
            var user = _context.Users.Include(u => u.UserUserCases)
                .FirstOrDefault(x => x.Username == username && x.Password == password);

           if (user == null)
            {
                return null;
            }

            var actor = new JwtActor
            {
               Id = user.Id,
                AllowedUseCases = user.UserUserCases.Select(x => x.UseCaseId),
                Identity = user.Username
            };

            var issuer = "asp_api";
            var secretKey = "ThisIsMyVerySecretKey";
            var claims = new List<Claim> // Jti : "", 
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString(), ClaimValueTypes.String, issuer),
                new Claim(JwtRegisteredClaimNames.Iss, "asp_api", ClaimValueTypes.String, issuer),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64, issuer),
                new Claim("UserId", actor.Id.ToString(), ClaimValueTypes.String, issuer),
                new Claim("ActorData", JsonConvert.SerializeObject(actor), ClaimValueTypes.String, issuer)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var now = DateTime.UtcNow;
            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: "Any",
                claims: claims,
                notBefore: now,
                expires: now.AddSeconds(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
