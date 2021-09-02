using Newtonsoft.Json;
using PatchedTOAuth.Models;
using PatchedTOAuth.Utils;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PatchedTOAuth.Auth
{
    public class AuthControl
    {
        public string AuthKey { get; set; }
        public string AppName { get; set; } = "PatchedTO";

        public RequestController requestController;
        
        public AuthControl(string authKey)
        {
            AuthKey = authKey;
            requestController = new RequestController();
        }
        public AuthControl(string authKey, string appName)
        {
            AuthKey = authKey;
            AppName = appName; 
            requestController = new RequestController();
        }

        public async Task<StatusData> GetStatusAsync(HttpMethod httpMethod = null)
        {
            var headers = new Dictionary<string, string>()
            {
                { "User-Agent", AppName },
                { "X-Auth-Key", AuthKey },
                { "Accept", "application/json" }
            };

            var request = await requestController.SendAsync(httpMethod: httpMethod, headers);

            return JsonConvert.DeserializeObject<StatusData>(request);
        }
    }
}
