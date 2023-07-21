using Microsoft.AspNetCore.Http;
using System.IO;
using System;

namespace Assignment02.Helper
{
    public static class DocumentSettings
    {
        public static string UploadFile(IFormFile file, string folderName)
        {
            //var folderPath = @"C:\Users\hp\OneDrive - Faculty of Computers and Information\Desktop\Assignment02\ASPCoreMVCAssignment02\wwwroot\Imgs\";
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folderName);

            var fileName = $"{Guid.NewGuid()}{Path.GetFileName(file.FileName)}";

            var filePath = Path.Combine(folderPath, fileName);

            using var fileStream = new FileStream(filePath, FileMode.Create);

            file.CopyTo(fileStream);

            return fileName;
        }
        public static void DeleteFile(string folderName,string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folderName, fileName);

            if (File.Exists(filePath))
                File.Delete(filePath);
        }

    }
}
