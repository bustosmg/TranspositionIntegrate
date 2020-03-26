using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TranspositionWeb.Contexto;
using TranspositionWeb.Models;

namespace TranspositionWeb.Controllers
{
    public class NotasController : Controller
    {
        private readonly DBContexto _context;
        private readonly ILogger<NotasController> _logger;

        public NotasController(DBContexto context, ILogger<NotasController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet("/GetTestLog")]
        public ActionResult GetTestLog()
        {
            int interacion = int.Parse(DateTime.Now.ToString());

            _logger.LogDebug($"Debug {interacion}");
            _logger.LogInformation($"LogInformation {interacion}");
            _logger.LogWarning($"LogWarning {interacion}");
            _logger.LogError($"LogError {interacion}");
            _logger.LogCritical($"LogCritical {interacion}");

            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return NoContent();
        }



        // GET: Notas
        public async Task<IActionResult> Index()
        {
            return View(await _context.notas.ToListAsync());
        }

        // GET: Notas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notasModel = await _context.notas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notasModel == null)
            {
                return NotFound();
            }

            return View(notasModel);
        }

        // GET: Notas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Notas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,notasCromaticas,IsChecked")] NotasModel notasModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(notasModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(notasModel);
        }

        // GET: Notas/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        public async Task<IActionResult> Edit()
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var notasModel = await _context.notas.FindAsync(id);
            var notasModel = await _context.notas.ToListAsync();
            if (notasModel == null)
            {
                return NotFound();
            }
            return View(notasModel);
        }

        // POST: Notas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[HttpPatch]
        [ValidateAntiForgeryToken]
        //public ActionResult<IEnumerable<NotasModel>> Edit(int id, [Bind("Id,notasCromaticas,IsChecked")] NotasModel notasModel)
        public ActionResult<List<NotasModel>> Edit([Bind("Id,notasCromaticas,IsChecked")] NotasModel notasModel)
        {
            //if (id != notasModel.Id)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                try
                {
                    /* 
                     * Hacer transposicion
                     * mostrar en pantalla
                     
                    _context.Update(notasModel);
                    await _context.SaveChangesAsync();
                    */
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotasModelExists(notasModel.Id))
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
            return View(notasModel);
        }

        // GET: Notas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notasModel = await _context.notas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notasModel == null)
            {
                return NotFound();
            }

            return View(notasModel);
        }

        // POST: Notas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var notasModel = await _context.notas.FindAsync(id);
            _context.notas.Remove(notasModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotasModelExists(int id)
        {
            return _context.notas.Any(e => e.Id == id);
        }
    }
}
