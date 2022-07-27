using Newtonsoft.Json;

namespace Iot.Data.Configs
{
    public class CsvConfig
    {
        public const string SectionName = "CsvConfig";

        [JsonProperty("CultureInfo")]
        public string CultureInfo { get; set; }
        [JsonProperty("Delimiter")]
        public string Delimiter { get; set; }
        [JsonProperty("HasHeader")]
        public bool HasHeader { get; set; }
    }
}
