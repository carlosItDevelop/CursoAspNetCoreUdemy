using Cooperchip.ITDeveloper.Mvc.Intra;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Cooperchip.ITDeveloper.Mvc.Extensions.Identity.Services
{
    public class UnitOfUpload : IUnitOfUpload
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UnitOfUpload(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async void UploadImage(IFormFile file)
        {
            long totalBytes = file.Length;
            string fileName = file.FileName.Trim('"');
            fileName = fileName.Contains("\\") ? fileName.Substring(fileName.LastIndexOf("\\") + 1) : fileName;

            byte[] buffer = new byte[3 * 1024];
            using(FileStream output = System.IO.File.Create(ObterCaminhoMaisNomeDoArquivo(fileName)))
            {
                using (Stream input = file.OpenReadStream())
                {
                    int readBytes;
                    while((readBytes = input.Read(buffer, 0, buffer.Length)) > 0){
                        await output.WriteAsync(buffer, 0, readBytes);
                        totalBytes += readBytes;
                    }
                }
            }

        }

        private string ObterCaminhoMaisNomeDoArquivo(string fileName)
        {
            string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);

            return path + fileName;
        }
    }
}
