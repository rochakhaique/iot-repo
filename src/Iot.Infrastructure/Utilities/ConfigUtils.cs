using Iot.Infrastructure.Configs;
using System;
using System.Linq;

namespace Iot.Infrastructure.Utilities
{
    public static class ConfigUtils
    {
        public static string GetSasToken(this StorageAccountConfig config) => GetValueFromConnectionString(config.ConnectionString, "SharedAccessSignature");
        public static string GetBlobUri(this StorageAccountConfig config) => GetValueFromConnectionString(config.ConnectionString, "Blob");

        public static string GetValueFromConnectionString(string connectionString, string key)
        {
            string entry = connectionString.Split(';').First(uri => uri.Contains(key, StringComparison.InvariantCultureIgnoreCase));
            return entry[(entry.IndexOf("=") + 1)..];
        }
    }
}
