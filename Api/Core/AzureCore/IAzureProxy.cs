using System.IO;

namespace Api.Core.AzureCore
{
    public interface IAzureProxy
    {
        string SaveBlob(Stream stream, string containerName, string blobName);
    }
}
