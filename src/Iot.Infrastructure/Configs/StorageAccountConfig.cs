namespace Iot.Infrastructure.Configs
{
    public class StorageAccountConfig
    {
        public const string SectionName = "StorageAccountConfig";
        public string ContainerName { get; set; }
        public string ConnectionString { get; set; }
    }
}
