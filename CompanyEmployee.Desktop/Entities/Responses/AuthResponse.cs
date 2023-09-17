using System.Text.Json.Serialization;

namespace Entities.Responses
{
    public class AuthResponse
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }
    }
}
