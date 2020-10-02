using Cooperchip.ITDeveloper.Application.Extensions;
using Cooperchip.ITDeveloper.Data.ORM;
using Cooperchip.ITDeveloper.Domain.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooperchip.ITDeveloper.Mvc.Controllers
{
    public class CidController : Controller
    {
        private readonly ITDeveloperDbContext _context;

        public CidController(ITDeveloperDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cid.AsNoTracking()
                .Where(c => c.CidInternalId < 1001)
                .OrderBy(o => o.CidInternalId)
                .ToListAsync());
        }

        public IActionResult ArquivoInvalido()
        {
            TempData["ArquivoInvalido"] = "O Arquivo não é válido!";
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> ImportCid(IFormFile file, [FromServices] IWebHostEnvironment webHostEnvironment)
        {
            // DRY
            if (!ArquivoValido.EhValido(file, "Cid.Csv")) return RedirectToAction("ArquivoInvalido"); // DELEGUEI

            var filePah = $"{webHostEnvironment.WebRootPath}\\importFiles\\{file.FileName}";

            CopiarArquivo.Copiar(file, filePah); // Deleguei

            int k = 0;
            string line;

            List<Cid> cids = new List<Cid>();
            Encoding encodingPage = Encoding.GetEncoding(1252);
            bool detectEncoding = false;

            using (var fs = System.IO.File.OpenRead(filePah))
            using (var stream = new StreamReader(fs, encoding: encodingPage, detectEncoding))
                while ((line = stream.ReadLine()) != null)
                {
                    string[] parts = line.Split(";");
                    // cidinternalid, codigo, diagnostico  (os campos que vem no cabecalho do .csv)
                    if (k > 0) // Pular Cabechalho
                    {
                        if (!_context.Cid.Any(e => e.CidInternalId == int.Parse(parts[0])))
                        {
                            cids.Add(new Cid
                            {
                                CidInternalId = int.Parse(parts[0]),
                                Codigo = parts[1],
                                Diagnostico = parts[2]
                            });
                        }
                    }
                    k++;
                }

            if (cids.Any())
            {
                await _context.AddRangeAsync(cids);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }


    }
}
