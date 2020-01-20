

using System.Collections.Generic;
using Valkyrie.Security.Extensions.Constants.Constraints;

namespace Valkyrie.Security.Extensions
{
    public class SecurityOptions
    {
        public SecurityOptions()
        {
            SaveTokens = true;
            RequireHttpsMetadata = false;
            Scopes=new List<string>();
        }
        public string AuthenticationScheme { get; set; }
        public string DefaultChallengeScheme { get; set; }
        public string IdentityServerUrl { get; set; }
        public bool SaveTokens { get; set; }
        public ICollection<string> Scopes { get; set; }
        public bool RequireHttpsMetadata { get; set; }
    }
}