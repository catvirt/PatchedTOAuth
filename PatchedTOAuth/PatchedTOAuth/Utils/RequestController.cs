using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PatchedTOAuth.Utils
{
    public class RequestController
    {
        private readonly string _crackedToAdress = "https://api.patched.to/v1/user_info";
        public async Task<string> SendAsync(HttpMethod httpMethod, Dictionary<string, string> Headers = null)
        {
            if (Headers is null)
            {
                throw new ArgumentNullException(nameof(Headers));
            }

            var httpClient = new HttpClient(new HttpClientHandler()
            {
                UseCookies = false,
                AllowAutoRedirect = true
            });

            using var sendRequest = new HttpRequestMessage(httpMethod, new Uri(_crackedToAdress));

            foreach (var text in Headers)
            {
                sendRequest.Headers.TryAddWithoutValidation(text.Key, text.Value);
            }

            var response = await httpClient.SendAsync(sendRequest);

            return await response.Content.ReadAsStringAsync();
        }
    }
}
