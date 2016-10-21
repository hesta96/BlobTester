namespace BlobTester.Common
{
    using System;
    using System.IO;

    using Microsoft.Azure;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;

    public class AzureFileUploadRepository : IFileUploadRepository
    {
        private string storageConnectionString;
        public string StorageConnectionString
        {
            get { return storageConnectionString; }
        }

        public AzureFileUploadRepository()
        {
            storageConnectionString = CloudConfigurationManager.GetSetting("StorageConnectionString");
        }

        public string UploadFile(byte[] file, Guid? fileName = null)
        {
            var container = this.GetContainer();

            if (!fileName.HasValue)
            {
                fileName = Guid.NewGuid();
            }

            var blockBlob = container.GetBlockBlobReference(fileName.ToString());
            using (var memStream = new MemoryStream(file))
            {
                blockBlob.UploadFromStream(memStream);
            }

            return fileName.Value.ToString();
        }

        private CloudBlobContainer GetContainer()
        {
            var storageAccount = CloudStorageAccount.Parse(storageConnectionString);
            var blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference("mycontainer");
            container.CreateIfNotExists();

            return container;
        }
    }
}
