using Microsoft.AspNetCore.Http;
using System.IO;

namespace Cooperchip.ITDeveloper.Application.Extensions
{
    public static class CopiarArquivo
    {
        public static void Copiar(IFormFile file, string filePath)
        {
            // if (!System.IO.File.Exists(filePath))
            //{
                using(FileStream fileStream = System.IO.File.Create(filePath))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                }
            //}
        }
    }
}
