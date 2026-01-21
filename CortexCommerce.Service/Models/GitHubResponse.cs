using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CortexCommerce.Service.Models
{
    public class GitHubResponse
    {
        [JsonPropertyName("choices")]
        public List<GitHubChoice> Choices { get; set; }
    }
    public class GitHubChoice
    {
        [JsonPropertyName("message")]
        public GitHubMessage Message { get; set; }
    }

    public class GitHubMessage
    {
        [JsonPropertyName("role")]
        public string Role { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }
    }
}