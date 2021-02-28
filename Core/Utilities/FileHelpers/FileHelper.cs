using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.FileHelpers
{
    public static class FileHelper
    {
        public static bool DeleteImage(string imagePath)
        {
            var exist = File.Exists(imagePath);
            if (exist)
            {
                File.Delete(imagePath);
                return true;
            }
            return false;
        }

        public static byte[] GetFileData(string imagePath)
        {
            byte[] byteArray = null;
            var result = File.OpenRead(imagePath);     
            if (result.Length > 0)
            {
                
                using (var streamReader = new MemoryStream())
                {
                    result.CopyTo(streamReader);
                    byteArray = streamReader.ToArray();
                }
                return byteArray;              
            }
            return byteArray;
        }

        public static string SaveImage(IFormFile formFile)
        {
            if (formFile != null)
            {
                var extension = CheckFileExtension(formFile);
                if (extension)
                {
                    var filePath = FilePathCreator();
                    var fileName = FileNameCreator(formFile.FileName);
                    CheckFilePathExists(filePath);
                    var fullFilePath = filePath + fileName;
                    using (var fileStream = File.Create(fullFilePath))
                    {
                        formFile.CopyTo(fileStream);
                        fileStream.Flush();
                    }
                    return fullFilePath;
                }
            }
            return null;
        }

        private static bool CheckFileExtension(IFormFile imageFile)
        {
            List<string> fileExtensions = new List<string> { ".JPEG", ".PNG", ".BMP", ".JPG", ".TIFF", ".SVG" };
            var fileInfo = new FileInfo(imageFile.FileName);
            var fileExtension = fileInfo.Extension.ToUpper();
            var result = fileExtensions.Any(f => f == fileExtension);
            if (result)
            {
                return result;
            }
            return result;
        }

        private static void CheckFilePathExists(string filePath)
        {
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
        }

        private static string FilePathCreator()
        {
            var fileRootName = @"\wwwroot\Images\";
            var fileRootPath = Directory.GetCurrentDirectory();
            var filePath = fileRootPath + fileRootName;
            return filePath;
        }

        private static string FileNameCreator(string fileName)
        {
            var fileInfo = new FileInfo(fileName);
            var randomGuid = Guid.NewGuid().ToString("N");
            var creatorFileName = randomGuid + fileInfo.Extension;
            return creatorFileName;
        }
    }
}
