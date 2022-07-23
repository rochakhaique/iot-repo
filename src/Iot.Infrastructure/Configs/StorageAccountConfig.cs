using System;
using System.Linq;

namespace Iot.Infrastructure.Configs
{
    public class StorageAccountConfig
    {
        public const string SectionName = "StorageAccountConfig";
        public string ContainerName { get; set; }
        public string ConnectionString { get; set; }
        public string SasToken => GetValueFromConnectionString("SharedAccessSignature");
        public string BlobUri => GetValueFromConnectionString("Blob");
        public string FileUri => GetValueFromConnectionString("File");
        public string QueueUri => GetValueFromConnectionString("Queue");
        public string TableUri => GetValueFromConnectionString("Table");

        private string GetValueFromConnectionString(string key)
        {
            string entry = ConnectionString.Split(';').First(uri => uri.Contains(key, StringComparison.InvariantCultureIgnoreCase));
            return entry[(entry.IndexOf("=") + 1)..];
        }
    }
}
