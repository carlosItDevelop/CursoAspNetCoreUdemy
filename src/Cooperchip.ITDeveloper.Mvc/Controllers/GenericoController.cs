using Cooperchip.ITDeveloper.Data.ORM;
using Cooperchip.ITDeveloper.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Cooperchip.ITDeveloper.Mvc.Controllers
{
    public class GenericoController : Controller
    {
        private readonly ITDeveloperDbContext _context;

        public GenericoController(ITDeveloperDbContext context)
        {
            _context = context;
        }

        //[Route("lista-de-genericos")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var listGenerico = await _context.Generico.AsNoTracking()
                .OrderBy(o => o.Codigo)
                .ToListAsync();
            return View(listGenerico);
        }

        //[Route("detalhe-de-generico/{id:guid}")]
        [HttpGet]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id.Value == null)
            {
                return NotFound();
            }

            var generico = await _context.Generico
                .FirstOrDefaultAsync(m => m.Id == id);
            if (generico == null)
            {
                return NotFound();
            }

            return View(generico);
        }

        //[Route("adicionar-generico")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //[Route("adicionar-generico")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Generico generico)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //generico.Id = Guid.NewGuid();
                    _context.Add(generico);
                    await _context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(generico);
        }

        //[Route("editar-generico/{id:guid}")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var generico = await _context.Generico.FindAsync(id);
            if (generico == null)
            {
                return NotFound();
            }
            return View(generico);
        }


        //[Route("editar-generico/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Generico generico)
        {
            if (id != generico.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(generico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GenericoExists(generico.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(generico);
        }

        //[Route("excluir-generico/{id:guid}")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var generico = await _context.Generico
                .FirstOrDefaultAsync(m => m.Id == id);
            if (generico == null)
            {
                return NotFound();
            }

            return View(generico);
        }

        //[Route("excluir-generico/{id:guid}"), ActionName("Delete")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var generico = await _context.Generico.FindAsync(id);
            _context.Generico.Remove(generico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GenericoExists(Guid id)
        {
            return _context.Generico.Any(e => e.Id == id);
        }
    }
}
