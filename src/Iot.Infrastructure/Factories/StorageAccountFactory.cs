using Azure;
using Azure.Storage.Blobs;
using Iot.Infrastructure.Configs;
using Iot.Infrastructure.Utilities;
using Microsoft.Extensions.Options;
using System;

namespace Iot.Infrastructure.Factories
{
    public class StorageAccountFactory
    {
        public BlobContainerClient BlobContainerClient { get; }

        public StorageAccountFactory(IOptions<StorageAccountConfig> options)
        {
            StorageAccountConfig config = options.Value;

            var sasCredential = new AzureSasCredential(config.GetSasToken());
            var blobUri = new Uri(config.GetBlobUri());
            var blobServiceClient = new BlobServiceClient(blobUri, sasCredential);
            BlobContainerClient = blobServiceClient.GetBlobContainerClient(config.ContainerName);
        }
    }
}
