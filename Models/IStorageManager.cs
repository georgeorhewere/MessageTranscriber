using Google.Cloud.Storage.V1;
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
        private string credentialFile = "transroute-164919-669cdebab53.json";
        //private string credentialFile = "transroute-164919-669cdebab534.json";
        private string bucketName = "rho-transcribe-files";
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
            try
            {
                var storage = StorageClient.Create();
                using (var fileInstance = File.OpenRead(path))
                {
                    var fileName = Path.GetFileName(path);
                    storage.UploadObject(bucketName, fileName, null, fileInstance);
                    return true;
                }

            }
            catch(Exception ex)
            {
                return false;
            }            
        }

        public bool setExternalCredentialFile (string filePath)
        {

            if (File.Exists(filePath))
            {
                System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filePath);
                return true;
            }

            return false;

        }

  
    }

}
