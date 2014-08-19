using Newtonsoft.Json;

namespace OTS
{
    public class LocalGSheet
    {
        [JsonProperty("url")]
        public string url { get; set; }
        [JsonProperty("resource_id")]
        public string resource_id { get; set; }
    }
}