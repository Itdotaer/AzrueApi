using System;
using System.Diagnostics;
using System.IO;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Api.Core.AzureCore
{
    public class DefaultAzureProxy : IAzureProxy, IDisposable
    {
        private const string BlobUrlFormat = "http://{0}.blob.core.chinacloudapi.cn/{1}/{2}";
        private readonly string _connectionString;
        private readonly string _storageAccountName;

        public DefaultAzureProxy(string connectionString, string storageAccountName)
        {
            _connectionString = connectionString;
            _storageAccountName = storageAccountName;
        }

        public string SaveBlob(Stream stream, string containerName, string blobName)
        {
            // Connect to Azure
            Trace.TraceInformation("[Azure:SaveBlob] Connecting to Azure...");
            var storageAccount = CloudStorageAccount.Parse(_connectionString);
            var blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve a reference toa container
            Trace.TraceInformation("[Azure:SaveBlob] Retrieving the container: {0}", containerName);
            var container = blobClient.GetContainerReference(containerName);

            // Create the container if it doesn't already exist
            container.CreateIfNotExists(BlobContainerPublicAccessType.Blob);

            // Upload a blob from the memory stream
            Trace.TraceInformation("[Azure:SaveBlob] Uploading the blob: {0}", blobName);
            var blob = container.GetBlockBlobReference(blobName);

            stream.Seek(0, SeekOrigin.Begin);
            blob.UploadFromStream(stream);
            Trace.TraceInformation("[Azure:SaveBlob] The file {0} has been uploaded to the Azure container :{1}", blobName, containerName);

            return string.Format(BlobUrlFormat, _storageAccountName, containerName, blobName);
        }

        public void Dispose()
        {          
            GC.SuppressFinalize(this);
        }
    }


}