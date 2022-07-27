using Newtonsoft.Json;

namespace Iot.Data.Configs
{
    public class MeasurementContentHandlerConfig
    {
        public const string SectionName = "MeasurementContentHandler";

        [JsonProperty("CsvConfig")]
        public CsvConfig CsvConfig { get; set; }
    }
}
