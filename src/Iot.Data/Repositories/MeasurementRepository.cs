using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Iot.Data.Interfaces;
using Iot.Infrastructure.Factories;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Iot.Data.Repositories
{
    public class MeasurementRepository : IMeasurementRepository
    {
        private readonly ILogger<MeasurementRepository> _logger;
        private readonly StorageAccountFactory _storageAccountFactory;

        public MeasurementRepository(ILogger<MeasurementRepository> logger, StorageAccountFactory storageAccountFactory)
        {
            _logger = logger;
            _storageAccountFactory = storageAccountFactory;
        }

        public async Task<BinaryData> GetContentAsync(string blobName)
        {
            try
            {
                BlobClient blobClient = _storageAccountFactory.BlobContainerClient.GetBlobClient(blobName);
                Response<BlobDownloadResult> response = await blobClient.DownloadContentAsync();

                return response.Value.Content;
            }
            catch (RequestFailedException ex)
            {
                _logger.LogError(ex, "Error on BlobClient request. [ {BlobName} ]", blobName);
                throw;
            }
        }
    }
}
