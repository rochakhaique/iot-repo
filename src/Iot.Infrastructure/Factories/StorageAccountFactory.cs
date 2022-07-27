using Azure;
using Azure.Storage.Blobs;
using Iot.Infrastructure.Configs;
using Iot.Infrastructure.Utilities;
using System;

namespace Iot.Infrastructure.Factories
{
    public class StorageAccountFactory
    {
        public BlobContainerClient BlobContainerClient { get; }

        public StorageAccountFactory(StorageAccountConfig config)
        {
            var blobUri = new Uri(config.GetBlobUri());
            var sasCredential = new AzureSasCredential(config.GetSasToken());
            var blobServiceClient = new BlobServiceClient(blobUri, sasCredential);
            BlobContainerClient = blobServiceClient.GetBlobContainerClient(config.ContainerName);
        }
    }
}
