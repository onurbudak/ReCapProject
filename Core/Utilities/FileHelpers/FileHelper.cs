using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.FileHelpers
{
    public class FileHelper
    {
        public static string SaveFile(IFormFile formFile, string [] fileExtensions)
        {
            if (formFile != null)
            {
                var extension = CheckFileExtension(formFile, fileExtensions);
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

        public static string UpdateFile(IFormFile formFile, string filePath, string [] fileExtensions)
        {
            var isDelete = DeleteFile(filePath);
            if (isDelete)
            {
                var fullFilePath = SaveFile(formFile, fileExtensions);
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

       
        private static bool CheckFileExtension(IFormFile formFile, string [] fileExtensions)
        {
            var fileExtension = Path.GetExtension(formFile.FileName).ToUpper();
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
            var fileRootName = @"Images\";
            var fileRootPath = Directory.GetCurrentDirectory() + @"\wwwroot\";
            var createdFilePath = fileRootPath + fileRootName;
            return createdFilePath;
        }

        private static string FileNameCreator(string fileName)
        {
            var fileExtension = Path.GetExtension(fileName);
            var randomGuid = Guid.NewGuid().ToString("N");
            var createdFileName = randomGuid + fileExtension;
            return createdFileName;
        }

        public static byte[] DefaultFileData()
        {
            var defaultFileDataPath = FilePathCreator() + "default.jpeg";
            var getFileData = GetFileData(defaultFileDataPath);
            return getFileData;
        }
    }
}
