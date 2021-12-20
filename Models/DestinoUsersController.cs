using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Agencia1.Data;

namespace Agencia1.Models
{
    public class DestinoUsersController : Controller
    {
        private readonly NovoUserContext _context;

        public DestinoUsersController(NovoUserContext context)
        {
            _context = context;
        }

        // GET: DestinoUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.DestinoUser.ToListAsync());
        }

        // GET: DestinoUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destinoUser = await _context.DestinoUser
                .FirstOrDefaultAsync(m => m.Id_Destino == id);
            if (destinoUser == null)
            {
                return NotFound();
            }

            return View(destinoUser);
        }

        // GET: DestinoUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DestinoUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Destino,País,Cidade,DataSaida,DataChegada")] DestinoUser destinoUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(destinoUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(destinoUser);
        }

        // GET: DestinoUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destinoUser = await _context.DestinoUser.FindAsync(id);
            if (destinoUser == null)
            {
                return NotFound();
            }
            return View(destinoUser);
        }

        // POST: DestinoUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Destino,País,Cidade,DataSaida,DataChegada")] DestinoUser destinoUser)
        {
            if (id != destinoUser.Id_Destino)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(destinoUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DestinoUserExists(destinoUser.Id_Destino))
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
            return View(destinoUser);
        }

        // GET: DestinoUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destinoUser = await _context.DestinoUser
                .FirstOrDefaultAsync(m => m.Id_Destino == id);
            if (destinoUser == null)
            {
                return NotFound();
            }

            return View(destinoUser);
        }

        // POST: DestinoUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var destinoUser = await _context.DestinoUser.FindAsync(id);
            _context.DestinoUser.Remove(destinoUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DestinoUserExists(int id)
        {
            return _context.DestinoUser.Any(e => e.Id_Destino == id);
        }
    }
}
