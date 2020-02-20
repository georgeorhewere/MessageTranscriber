using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageTranscriber.Models
{
    public interface IStorageManager
    {
        bool LoadCredentials();
        bool UploadFile(string path);
    }

    public class GCPStorageManager : IStorageManager
    {
        private string credentialFile = "transroute-164919-c04f428a0f49.json";
        public bool LoadCredentials()
        {

            string currentDirectory = Directory.GetCurrentDirectory();
            string filePath = System.IO.Path.Combine(currentDirectory, "Lib", credentialFile);
            
            
            if (File.Exists(filePath))
            {
                System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filePath);
                return true;
            }
            else
            {             
                return false;
            }
        }

        public bool UploadFile(string path)
        {
            throw new NotImplementedException();
        }

        //    Google docs example
        //private void UploadFile(string bucketName, string localPath,
        //string objectName = null)
        //    {
        //        var storage = StorageClient.Create();
        //        using (var f = File.OpenRead(localPath))
        //        {
        //            objectName = objectName ?? Path.GetFileName(localPath);
        //            storage.UploadObject(bucketName, objectName, null, f);
        //            Console.WriteLine($"Uploaded {objectName}.");
        //        }
        //    }
    }

}
