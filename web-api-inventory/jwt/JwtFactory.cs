using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using web_api_inventory.Helpers;
using static web_api_inventory.Helpers.ConstantJwt.Strings;

namespace web_api_inventory.jwt {
    public class JwtFactory : IJwtFactory {
        private readonly JwtOptions _jwtOptions;

        public JwtFactory (IOptions<JwtOptions> jwtOptions) {
            _jwtOptions = jwtOptions.Value;

            if (_jwtOptions == null) throw new ArgumentNullException (nameof (jwtOptions));
            if (_jwtOptions.ValidFor <= TimeSpan.Zero) {
                throw new ArgumentException ("Must be a non-zero TimeSpan.", nameof (JwtOptions.ValidFor));
            }
            if (_jwtOptions.SigningCredentials == null) {
                throw new ArgumentNullException (nameof (JwtOptions.SigningCredentials));
            }
            if (_jwtOptions.JtiGenerator == null) {
                throw new ArgumentNullException (nameof (JwtOptions.JtiGenerator));
            }
        }

        public async Task<string> GenerateEncodedToken (string userName, ClaimsIdentity identity) {
            var claims = new [] {
                new Claim (JwtRegisteredClaimNames.Sub, userName),
                new Claim (JwtRegisteredClaimNames.Jti, await _jwtOptions.JtiGenerator ()),
                new Claim (JwtRegisteredClaimNames.Iat, ToUnixEpochDate (_jwtOptions.IssuedAt).ToString (), ClaimValueTypes.Integer64),
                identity.FindFirst (JwtClaimIdentifiers.Rol),
                identity.FindFirst (JwtClaimIdentifiers.Id)
            };

            // Create the JWT security token and encode it.
            var jwt = new JwtSecurityToken (
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                notBefore: _jwtOptions.NotBefore,
                expires: _jwtOptions.Expiration,
                signingCredentials: _jwtOptions.SigningCredentials);

            var encodedJwt = new JwtSecurityTokenHandler ().WriteToken (jwt);

            return encodedJwt;
        }

        public ClaimsIdentity GenerateClaimsIdentity (string userName, string id) {
            return new ClaimsIdentity (new GenericIdentity (userName, "Token"), new [] {
                new Claim (ConstantJwt.Strings.JwtClaimIdentifiers.Rol, id),
                    new Claim (ConstantJwt.Strings.JwtClaimIdentifiers.Rol, ConstantJwt.Strings.JwtClaims.ApiAccess)
            });
        }

        private static long ToUnixEpochDate (DateTime date) => (long) Math.Round ((date.ToUniversalTime () -
                new DateTimeOffset (1970, 1, 1, 0, 0, 0, TimeSpan.Zero))
            .TotalSeconds);
    }
}