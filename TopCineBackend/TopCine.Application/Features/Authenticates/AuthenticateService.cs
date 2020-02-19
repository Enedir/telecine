using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using TopCine.Domain.Features.Users;
using TopCine.Infra.Commun;
using TopCine.Infra.Extension_Methods;

namespace TopCine.Application.Features.Authenticates
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly IUserRepository _reposotory;
        private readonly AppSettings _appSettings;


        public AuthenticateService(IOptions<AppSettings> appSettings, IUserRepository repository)
        {
            _appSettings = appSettings.Value;
            _reposotory = repository;
        }

        public User Authenticate(string email, string password)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                string passwordHash = md5Hash.GetMd5Hash(password);

                var user = _reposotory.GetByEmailAndPassword(email, passwordHash);

                // return null if user not found
                if (user == null)
                    return null;

                // authentication successful so generate jwt token
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.SetToken(tokenHandler.WriteToken(token));

                return user;
            }
        }
    }
}
