using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHelper
    {
        public IDataResult<string> CreateFile(IFormFile file, string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            if (file.FileName.Length == 0)
            {
                return new ErrorDataResult<string>("File name can not be empty.");
            }
            string extension = Path.GetExtension(file.FileName);
            string guid = GuidHelper.GuidHelper.CreateGuid();
            string filePath = guid + extension;
            using (FileStream fileStream = File.Create(directoryPath + filePath))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }

            return new SuccessDataResult<string>(filePath, "File sucessfully created");
        }
        public IResult DeleteFile(string filePath)
        {
            string _filePath = Path.GetFullPath(filePath);
            if (!File.Exists(_filePath))
            {
                return new ErrorResult("File path not found.");
            }
            File.Delete(_filePath);
            return new SuccessResult("File sucessfully deleted");
        }
    }
}
