using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using TicketSystem.DataAccess.Model;
using TicketSystem.Service.Models;

namespace TicketSystem.Service.Service
{
    public class JwtSettings
    {
        private readonly string _key;
        private readonly string _issuer;
        private readonly SymmetricSecurityKey _securityKey;
        private readonly SigningCredentials _credentials;
        private readonly JwtSecurityTokenHandler _handler = new JwtSecurityTokenHandler();
        private readonly TimeSpan _expired = TimeSpan.FromHours(2);

        public JwtSettings(string key, string issuer)
        {
            _key = key;
            _issuer = issuer;
            _securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            _credentials = new SigningCredentials(_securityKey, SecurityAlgorithms.HmacSha256);
        }
        public JwtToken CreateToken(UserModel user)
        {
            var sessionId = NewSessionId();
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, sessionId),
                new Claim("UserId", user.Id.ToString()),
                new Claim("Account", user.Account),
            };
            var securityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.Add(_expired),
                signingCredentials: _credentials);
            var token = _handler.WriteToken(securityToken);
            var result = new JwtToken(sessionId, token);

            return result;
        }

        private string NewSessionId()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}