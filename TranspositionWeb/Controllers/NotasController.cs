using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TranspositionWeb.Contexto;
using TranspositionWeb.DTOs;
using TranspositionWeb.Models;

namespace TranspositionWeb.Controllers
{
     

    public class NotasController : Controller
    {
        private readonly DBContexto _context;
        private readonly ILogger<NotasController> _logger;
        private Dictionary<string, int> dTransposicion;

        public NotasController(DBContexto context, ILogger<NotasController> logger)
        {
            _context = context;
            _logger = logger;
            dTransposicion = new Dictionary<string, int>()
            {
                { "SaxoAlto", 2 },
                { "SaxoTenor", 1 },
                { "Piano", 0 },
            };
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
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notasModel = await _context.notas.FindAsync(id);
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,notasCromaticas,IsChecked")] List<NotasModel> notasModel)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    List<NotasModel> notasVista = new List<NotasModel>();
                    List<NotaModelTransDTO> notasTrans = new List<NotaModelTransDTO>();

                    foreach (NotasModel item in notasModel)
                    {
                        var notasVistaz = _context.notas.Find(item.Id);
                        notasVista.Add(notasVistaz);

                        if (item.IsChecked)
                        {
                            /*
                             de que a que intrumento
                             1 = Eb
                             2 = Bb
                             */


                            int tonosTrans = item.InstrumentoDestino==1 ? dTransposicion["SaxoAlto"] : dTransposicion["SaxoTenor"];
                            int ids = item.Id + tonosTrans;
                            NotasModel notaModelo = _context.notas.Find(ids);

                            NotaModelTransDTO notaTranz = new NotaModelTransDTO()
                            {
                                Id = notaModelo.Id,
                                notasOrigen=item.notasCromaticas,
                                notasTranspuesta = notaModelo.notasCromaticas,
                                IsChecked=notaModelo.IsChecked
                            };

                            notasTrans.Add(notaTranz);
                        } 

                    }
                    ViewBag.PostBack = notasTrans;
                    return View("Index", notasVista );

                    //_context.Update(notasModel);
                    //await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    if (!NotasModelExists(notasModel))
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

        private bool NotasModelExists(List<NotasModel> notasmodel)
        {
            foreach (var item in notasmodel)
            {
                try
                {
                    if (!_context.notas.Any(e => e.Id == item.Id))
                        return false;

                }
                catch (Exception)
                {

                    throw;

                }
                return false;

            }
            return true;
        }
    }
}
