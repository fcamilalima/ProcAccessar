using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProcAccessar.Context;
using ProcAccessar.Models;
using ProcAccessar.ViewModels;
using ReflectionIT.Mvc.Paging;
using System.Linq;

namespace ProcAccessar.Controllers
{
    public class ProcessosController : Controller
    {
        private readonly AppDbContext _context;

        public ProcessosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Processos
        //public async Task<IActionResult> Index(string PalavraBusca = "")
        //{
        //    var processos = from p in _context.Processos
        //                    select p;

        //    if (!string.IsNullOrEmpty(PalavraBusca))
        //    {
        //        processos = processos.Where(s => s.Titulo.Contains(PalavraBusca));
        //    }
        //    processos = processos.OrderBy(s => s.Codigo);
        //    return View(await processos.ToListAsync());
        //}

        public async Task<IActionResult> Index(string filter, int pageindex, string sort= "Titulo")
        {
            var resultado = _context.Processos.AsNoTracking().AsQueryable();
            if (!string.IsNullOrEmpty(filter))
            {
                resultado = resultado.Where(s => s.Titulo.Contains(filter));
            }

            var model = await PagingList.CreateAsync(resultado, 5, pageindex, sort, "Titulo");

            model.RouteValue = new RouteValueDictionary { { "filter", filter } };

            return View(model);
        }
       
            public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var processo = await _context.Processos
                .FirstOrDefaultAsync(m => m.ProcessoId == id);
            if (processo == null)
            {
                return NotFound();
            }

            return View(processo);
        }

        // GET: Processos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Processos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProcessoId,Codigo,Titulo,Descricao,DataCriacao,CategoriaId")] Processo processo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(processo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(processo);
        }

        // GET: Processos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var processo = await _context.Processos.FindAsync(id);
            if (processo == null)
            {
                return NotFound();
            }
            return View(processo);
        }

        // POST: Processos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProcessoId,Codigo,Titulo,Descricao,DataCriacao,CategoriaId")] Processo processo)
        {
            if (id != processo.ProcessoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(processo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcessoExists(processo.ProcessoId))
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
            return View(processo);
        }

        // GET: Processos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var processo = await _context.Processos
                .FirstOrDefaultAsync(m => m.ProcessoId == id);
            if (processo == null)
            {
                return NotFound();
            }

            return View(processo);
        }

        // POST: Processos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var processo = await _context.Processos.FindAsync(id);
            _context.Processos.Remove(processo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: ProcessoPesquisaViewModel
        public async Task<IActionResult> Search()
        {
            return View();
        }

        [HttpPost, ActionName("Search")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Search(string palavraBusca)
        {
            return View(_context.Processos.Where(p => p.Titulo.Contains(palavraBusca)).OrderBy(p => p.Titulo));
        }
        private bool ProcessoExists(int id)
        {
            return _context.Processos.Any(e => e.ProcessoId == id);
        }
    }
}
