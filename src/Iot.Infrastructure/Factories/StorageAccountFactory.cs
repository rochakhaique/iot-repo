using Azure.Storage.Blobs;
using Iot.Infrastructure.Configs;
using Microsoft.Extensions.Options;
using System;

namespace Iot.Infrastructure.Factories
{
    public class StorageAccountFactory
    {
        public StorageAccountFactory(IOptions<StorageAccountConfig> options)
        {
            StorageAccountConfig config = options.Value;

            var sasCredential = new Azure.AzureSasCredential(config.SasToken);
            var _blobServiceClient = new BlobServiceClient(new Uri(config.BlobUri), sasCredential);
            BlobContainerClient = _blobServiceClient.GetBlobContainerClient(config.ContainerName);
        }

        public BlobContainerClient BlobContainerClient { get; set; }
    }
}
