using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OnionArch.Application.Abstractions;
using OnionArch.Application.DTOs;

namespace OnionArch.Infrastructure.Services
{
    public class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration configuration;
        public TokenHandler(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public Token CreateAccessToken(int minute)
        {
            Token token = new Token();

            SymmetricSecurityKey symmetricSecurityKey = new(Encoding.UTF8.GetBytes(configuration["Token:SecurityKey"]));

            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            token.Expiration = DateTime.UtcNow.AddMinutes(minute);
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                audience: configuration["Token:Audience"],
                issuer: configuration["Token:Issuer"],
                expires: token.Expiration,
                notBefore: DateTime.UtcNow,
                signingCredentials: signingCredentials
                );

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            token.AccessToken = tokenHandler.WriteToken(jwtSecurityToken);

            token.RefreshToken = CreateRefreshToken();

            return token;
        }

        public string CreateRefreshToken()
        {
            byte[] number = new byte[32];
            using var random = RandomNumberGenerator.Create();
            random.GetBytes(number);
            return Convert.ToBase64String(number);

        }
    }
}
