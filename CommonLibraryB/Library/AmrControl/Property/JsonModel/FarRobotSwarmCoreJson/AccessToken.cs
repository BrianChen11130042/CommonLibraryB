using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibraryB.Library.AmrControl.Property.JsonModel.FarRobotSwarmCoreJson
{
    public class AccessToken
    {
        public Dictionary<string, string> post { get; set; } = new Dictionary<string, string>();

        public TokenResponse response { get; set; } = new TokenResponse();
    }

    public class TokenResponse
    {
        public string access_token { get; set; }

        public string token_type { get; set; }
    }
}
