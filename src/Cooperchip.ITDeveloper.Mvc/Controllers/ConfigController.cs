
using Cooperchip.ITDeveloper.Application.Extensions;
using Cooperchip.ITDeveloper.Data.ORM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Cooperchip.ITDeveloper.Mvc.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ConfigController : Controller
    {
        // POR QQ MOTIVO NÃO PUDE CRIAR O CTOR OU MESMO INJETAR POR AQUI >> (SEM CONSTRUTOR)

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ImportMedicamentos([FromServices] ITDeveloperDbContext context)
        {
            var filePath = ImportUtils.GetFilePath("Csv", "Medicamentos", ".CSV"); // DELEGUEI

            /// Não importa para esta classe saber como é implementada a leitura e gravação - DELEGUEI
            ReadWriteFile rwf = new ReadWriteFile(); 
            if (!await rwf.ReadAndWriteCsvAsync(filePath, context)) return View("JaTemMedicamento", context.Medicamento.AsNoTracking().OrderBy(o => o.Codigo));

            return View("ListaMedicamentos", context.Medicamento.AsNoTracking().OrderBy(o => o.Codigo));
        }


    }
}
