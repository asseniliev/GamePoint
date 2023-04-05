using MatchScore.Data.Constants;
using MatchScore.Data.Models;
using MatchScore.Exceptions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace MatchScore.Web.Helpers
{
    public class AuthHelper
    {
        private readonly IConfiguration configuration;

        public AuthHelper(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void CreatePasswordHash(string password, out byte[] passwordSalt, out byte[] passwordHash)
        {
            using (HMACSHA512 hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;

                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public bool VerifyPasswordHash(string password, byte[] passwordSalt, byte[] passwordHash)
        {
            using (HMACSHA512 hmac = new HMACSHA512(passwordSalt))
            {
                byte[] computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                return computedHash.SequenceEqual(passwordHash);
            }
        }

        public void UpdatePasswordHash(string password, byte[] passwordSalt, out byte[] passwordHash)
        {
            using (HMACSHA512 hmac = new HMACSHA512(passwordSalt))
            {
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim("username", user.Username),
                new Claim("role", user.Role.ToString())
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.configuration["JwtToken:SecretKey"]));

            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            JwtSecurityToken jwtToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(int.Parse(this.configuration["JwtToken:TokenExpiry"])),
                signingCredentials: credentials,
                audience: this.configuration["JwtToken:Audience"],
                issuer: this.configuration["JwtToken:Issuer"]);

            string jwtTokenString = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return jwtTokenString;
        }

        public string[] ProcessCredentials(string credentials)
        {
            if (string.IsNullOrWhiteSpace(credentials))
            {
                throw new UnauthorizedOperationException(Messages.UnauthenticatedError);
            }

            string[] credentialsArray = credentials.Split(':');

            return credentialsArray;
        }
    }
}
