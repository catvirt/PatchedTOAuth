using Newtonsoft.Json;

namespace PatchedTOAuth.Models
{
    public class StatusData
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("session_info")]
        public SessionInfo SessionInfo { get; set; }

        [JsonProperty("user_info")]
        public UserInfo UserInfo { get; set; }

    }
    public class SessionInfo
    {
        [JsonProperty("time")]
        public int Time { get; set; }
    }
    public class UserInfo
    {
        [JsonProperty("user")]
        public string User { get; set; }

        [JsonProperty("uid")]
        public int Uid { get; set; }

        [JsonProperty("rank")]
        public string Rank { get; set; }

        [JsonProperty("ip")]
        public string Ip { get; set; }

        [JsonProperty("post")]
        public string Post { get; set; }

        [JsonProperty("rep")]
        public string Rep { get; set; }

        [JsonProperty("exp")]
        public int Exp { get; set; }
    }
}
