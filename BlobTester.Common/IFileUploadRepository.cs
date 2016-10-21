namespace BlobTester.Common
{
    using System;

    public interface IFileUploadRepository
    {
        string UploadFile(byte[] file, Guid? fileName = null);
    }
}
