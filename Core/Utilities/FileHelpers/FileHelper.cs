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
        public static string SaveFile(IFormFile formFile)
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

        public static string UpdateFile(IFormFile formFile,string filePath)
        {
            var isDelete = DeleteFile(filePath);
            if (isDelete)
            {
                var fullFilePath = SaveFile(formFile);
                return fullFilePath;
            }
            return null;
        }

        public static bool DeleteFile(string filePath)
        {
            var exist = File.Exists(filePath);
            if (exist)
            {
                File.Delete(filePath);
                return exist;
            }
            return exist;
        }

        public static byte[] GetFileData(string filePath)
        {
            byte[] byteArray = null;
            var result = File.OpenRead(filePath);
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

       
        private static bool CheckFileExtension(IFormFile formFile)
        {
            List<string> fileExtensions = new List<string> { ".JPEG", ".PNG", ".BMP", ".JPG", ".TIFF", ".SVG" };
            var fileInfo = new FileInfo(formFile.FileName);
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
            var createdFilePath = fileRootPath + fileRootName;
            return createdFilePath;
        }

        private static string FileNameCreator(string fileName)
        {
            var fileInfo = new FileInfo(fileName);
            var randomGuid = Guid.NewGuid().ToString("N");
            var createdFileName = randomGuid + fileInfo.Extension;
            return createdFileName;
        }

        public static byte[] DefaultFileData()
        {
            var defaultFileDataPath = FilePathCreator() + "default.png";
            var getFileData = GetFileData(defaultFileDataPath);
            return getFileData;
        }
    }
}
