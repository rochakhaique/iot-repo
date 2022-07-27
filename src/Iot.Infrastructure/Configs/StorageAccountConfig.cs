using Newtonsoft.Json;

namespace Iot.Infrastructure.Configs
{
    public class StorageAccountConfig
    {
        public const string SectionName = "StorageAccount";

        [JsonProperty("ContainerName")]
        public string ContainerName { get; set; }
        [JsonProperty("ConnectionString")]
        public string ConnectionString { get; set; }
    }
}
