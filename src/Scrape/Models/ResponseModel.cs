using System.Collections.Generic;
using System.Text.Json.Serialization;

#pragma warning disable SA1402
#pragma warning disable CA1056

namespace Scrape.Model
{
    public class Orig
    {
        public int Width { get; set; }

        public int Height { get; set; }

        public string Url { get; set; }
    }

    public class Images
    {
        [JsonPropertyName("orig")]
        public Orig Orig { get; set; }
    }

    public class Result
    {
        [JsonPropertyName("images")]
        public Images Images { get; set; }
    }

    public class Data
    {
        [JsonPropertyName("results")]
        public IList<Result> Results { get; set; }
    }

    public class ResourceResponse
    {
        [JsonPropertyName("data")]
        public Data Data { get; set; }
    }

    public class ResponseModel
    {
        [JsonPropertyName("resource_response")]
        public ResourceResponse Resource_response { get; set; }
    }
}
