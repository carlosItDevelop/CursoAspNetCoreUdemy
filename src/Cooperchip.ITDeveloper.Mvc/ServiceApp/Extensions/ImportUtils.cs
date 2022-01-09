using System;
using System.IO;
using System.Reflection;

namespace Cooperchip.ITDeveloper.Application.Extensions
{
    public static class ImportUtils
    {
        // Esta classe tem apenas uma única responsabilidade!!! MARAVILHA
        public static string GetFilePath(string raiz, string filename, string extesion)
        {
            // A maneira como é implementado este método não interessa para quem chama! BELEZA?
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            var csvPath = Path.Combine(outPutDirectory, $"{raiz}\\{filename}{extesion}");
            return new Uri(csvPath).LocalPath;

        }
    }
}
