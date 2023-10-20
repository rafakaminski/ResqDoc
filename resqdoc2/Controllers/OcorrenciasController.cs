using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using resqdoc2.Enums;

using resqdoc2.Models;
using resqdoc2.Models.ResqDoc.Models;

namespace resqdoc2.Controllers
{
    public class OcorrenciasController : Controller
    {
        private readonly Context _context;

        public OcorrenciasController(Context context)
        {
            _context = context;
        }

        // GET: Ocorrencias

        public IActionResult Index(string busca, string filtro)
        {
            // Obtenha todos os registros de ocorrência do banco de dados
            var ocorrencias = _context.Ocorrencia.ToList();

            // Se a pesquisa não estiver vazia e o filtro for "titulo", filtre os resultados pelo título
            if (!string.IsNullOrEmpty(busca) && filtro == "titulo")
            {
                busca = busca.ToLower(); // Converta a pesquisa para minúsculas para tornar a pesquisa insensível a maiúsculas e minúsculas

                ocorrencias = ocorrencias.Where(o =>
                    o.Titulo.ToLower().Contains(busca)
                ).ToList();
            }

            // Se a pesquisa não estiver vazia e o filtro for "cobrade", filtre os resultados pelo Cobrade
            //if (!string.IsNullOrEmpty(busca) && filtro == "cobrade")
            //{
            //    // Converta a entrada em um número inteiro
            //    if (int.TryParse(busca, out int cobrade))
            //    {
            //        ocorrencias = ocorrencias.Where(o =>
            //            o.Cobrade == cobrade
            //        ).ToList();
            //    }
            //}

            return View(ocorrencias);
        }









        // GET: Ocorrencias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ocorrencia == null)
            {   
                return NotFound();
            }

            var ocorrencia = await _context.Ocorrencia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ocorrencia == null)
            {
                return NotFound();
            }

            return View(ocorrencia);
        }

        // GET: Ocorrencias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ocorrencias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Gravidade,Data,Cobrade")] Ocorrencia ocorrencia, string Data)
        {
            if (ModelState.IsValid)
            {
                // Converte a string Data em um DateTime
                if (DateTime.TryParseExact(Data, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dataConvertida))
                {
                    // Converte o DateTime para DateOnly
                    ocorrencia.Data = DateOnly.FromDateTime(dataConvertida);

                    _context.Add(ocorrencia);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("Data", "Formato de data inválido. Use o formato dd/MM/yyyy.");
                }
            }
            return View(ocorrencia);
        }



        // GET: Ocorrencias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ocorrencia == null)
            {
                return NotFound();
            }

            var ocorrencia = await _context.Ocorrencia.FindAsync(id);
            if (ocorrencia == null)
            {
                return NotFound();
            }
            return View(ocorrencia);
        }

        // POST: Ocorrencias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Gravidade,DateTime,Cobrade")] Ocorrencia ocorrencia)
        {
            if (id != ocorrencia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ocorrencia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OcorrenciaExists(ocorrencia.Id))
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
            return View(ocorrencia);
        }

        // GET: Ocorrencias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ocorrencia == null)
            {
                return NotFound();
            }

            var ocorrencia = await _context.Ocorrencia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ocorrencia == null)
            {
                return NotFound();
            }

            return View(ocorrencia);
        }

        // POST: Ocorrencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ocorrencia == null)
            {
                return Problem("Entity set 'Context.Ocorrencia'  is null.");
            }
            var ocorrencia = await _context.Ocorrencia.FindAsync(id);
            if (ocorrencia != null)
            {
                _context.Ocorrencia.Remove(ocorrencia);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OcorrenciaExists(int id)
        {
          return (_context.Ocorrencia?.Any(e => e.Id == id)).GetValueOrDefault();
        }

       
    }
}
