using Cooperchip.ITDeveloper.Mvc.Infra;
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
            fileName = ObterNomeDoArquivo(fileName);
            byte[] buffer = new byte[16 * 1024];
            using (FileStream outPut = System.IO.File.Create(ObterCaminhoCompleto(fileName)))
            {
                using (Stream input = file.OpenReadStream())
                {
                    int readBytes;
                    while ((readBytes = input.Read(buffer, 0, buffer.Length)) > 0 )
                    {
                        await outPut.WriteAsync(buffer, 0, readBytes);
                        totalBytes += readBytes;
                    }
                }
            }
        }

        private string ObterNomeDoArquivo(string fileName)
        {
            if (fileName.Contains("\\"))
                fileName = fileName.Substring(fileName.LastIndexOf("\\") + 1);

            return fileName;
        }

        private string ObterCaminhoCompleto(string fileName)
        {
            string caminho = _webHostEnvironment.WebRootPath + "\\uploads\\";
            if (!Directory.Exists(caminho))
                Directory.CreateDirectory(caminho);

            return caminho;
        }

    }
}
