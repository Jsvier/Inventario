using System;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace web_api_inventory.jwt {
    public class JwtOptions {
        public string Issuer { get; set; }
        public string Subject { get; set; }
        public string Audience { get; set; }
        public DateTime Expiration => IssuedAt.Add (ValidFor);
        public DateTime NotBefore => DateTime.UtcNow;
        public DateTime IssuedAt => DateTime.UtcNow;
        public TimeSpan ValidFor { get; set; } = TimeSpan.FromMinutes (120);
        public Func<Task<string>> JtiGenerator => () => Task.FromResult (Guid.NewGuid ().ToString ());
        public SigningCredentials SigningCredentials { get; set; }
    }
}