using Cooperchip.ITDeveloper.Data.ORM;
using Cooperchip.ITDeveloper.Domain.Entities;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Cooperchip.ITDeveloper.Application.Extensions
{
    public class ReadWriteFile
    {
        // Não precisaremos de um contrutor, pois quando não temos nenhum é chamado o padrão: LEMBRAM-SE???
        public ReadWriteFile(){}

        // Responsabilidade de Ler e Gravar o arquivo importado

        public async Task<bool> ReadAndWriteCsvAsync(string filePath, ITDeveloperDbContext ctx)
        {


            var k = 0;
            string line;

            using (var fs = System.IO.File.OpenRead(filePath))
            using (var sreader = new StreamReader(fs))
                while ((line = sreader.ReadLine()) != null)
                {
                    var parts = line.Split(";");

                    // Pular o cabeçalho
                    if (k > 0)
                    {
                        var codigomedicamento = parts[0];
                        var descricao = parts[1];
                        var generico = parts[2];
                        var codigogenerico = parts[3];

                        // TODO: Considerando que os valores dos imports são sempre iguais, portanto qq registro que já exista a gente aborta
                        if (JaTemMedicamanto(codigomedicamento, ctx)) return false;

                        ctx.Add(new Medicamento
                        {
                            Codigo = int.Parse(codigomedicamento),
                            Descricao = descricao,
                            Generico = generico,
                            CodigoGenerico = int.Parse(codigogenerico)
                        });
                    }
                    k++;
                }

            await ctx.SaveChangesAsync();

            return true;
        }

        private bool JaTemMedicamanto(string codigomedicamento, ITDeveloperDbContext ctx)
        {
            return ctx.Medicamento.Any(e => e.Codigo == int.Parse(codigomedicamento));
        }
    }
}
