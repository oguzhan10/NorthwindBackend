using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Utilities.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }
        private TokenOptions _tokenOptions;
        private DateTime _accessTokenExpriation;

        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            //takes from appsetttings tokenoptions info and set it to _tokenOptions
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            _accessTokenExpriation = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
        }

        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);

            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);



        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOption1s, User user, 
            SigningCredentials signingCredentials,List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                    issuer: tokenOption1s.Issuer,
                    audience: tokenOption1s.Audience,
                    expires: _accessTokenExpriation,
                    notBefore:DateTime.Now,
                    claims: SetClaims(user,operationClaims),
                    signingCredentials : signingCredentials
                );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user,List<OperationClaim> operaionClaims)
        {
            var claims = new List<Claim>();
            
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName } {user.LastName}");
            claims.AddRoles(operaionClaims.Select( c => c.Name).ToArray());
            return claims;
        }

    }
}
