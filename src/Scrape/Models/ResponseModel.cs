using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#pragma warning disable SA1402
#pragma warning disable CA1056

namespace Scrape.Models
{
    public class Image
    {
        public int Height { get; set; }

        public string Url { get; set; } = string.Empty;

        public int Width { get; set; }
    }

    public class Images
    {
        [JsonPropertyName("136x136")]
        public Image Image136 { get; set; } = new();

        [JsonPropertyName("170x")]
        public Image Image170 { get; set; } = new();

        [JsonPropertyName("236x")]
        public Image Image236 { get; set; } = new();

        [JsonPropertyName("474x")]
        public Image Image474 { get; set; } = new();

        [JsonPropertyName("736x")]
        public Image Image736 { get; set; } = new();

        [JsonPropertyName("orig")]
        public Image Orig { get; set; } = new();
    }

    public class Result
    {
        [JsonPropertyName("images")]
        public Images Images { get; set; } = new();
    }

    public class Data
    {
        [JsonPropertyName("results")]
        public IEnumerable<Result> Results { get; set; } = Array.Empty<Result>();
    }

    public class ResourceResponse
    {
        [JsonPropertyName("data")]
        public Data Data { get; set; } = new();
    }

    public class ResponseModel
    {
        [JsonPropertyName("resource_response")]
        public ResourceResponse ResourceResponse { get; set; } = new();
    }
}
