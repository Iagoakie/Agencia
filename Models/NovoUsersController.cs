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
    public class NovoUsersController : Controller
    {
        private readonly NovoUserContext _context;

        public NovoUsersController(NovoUserContext context)
        {
            _context = context;
        }

        // GET: NovoUsers
        public async Task<IActionResult> Index()
        {
            var novoUserContext = _context.NovoUsers.Include(n => n.DestinoUser);
            return View(await novoUserContext.ToListAsync());
        }

        // GET: NovoUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var novoUser = await _context.NovoUsers
                .Include(n => n.DestinoUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (novoUser == null)
            {
                return NotFound();
            }

            return View(novoUser);
        }

        // GET: NovoUsers/Create
        public IActionResult Create()
        {
            ViewData["DestinoUserId_Destino"] = new SelectList(_context.DestinoUser, "Id_Destino", "Cidade");
            return View();
        }

        // POST: NovoUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,CPF,Email,DestinoUserId_Destino")] NovoUser novoUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(novoUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DestinoUserId_Destino"] = new SelectList(_context.DestinoUser, "Id_Destino", "Cidade", novoUser.DestinoUserId_Destino);
            return View(novoUser);
        }

        // GET: NovoUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var novoUser = await _context.NovoUsers.FindAsync(id);
            if (novoUser == null)
            {
                return NotFound();
            }
            ViewData["DestinoUserId_Destino"] = new SelectList(_context.DestinoUser, "Id_Destino", "Cidade", novoUser.DestinoUserId_Destino);
            return View(novoUser);
        }

        // POST: NovoUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,CPF,Email,DestinoUserId_Destino")] NovoUser novoUser)
        {
            if (id != novoUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(novoUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NovoUserExists(novoUser.Id))
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
            ViewData["DestinoUserId_Destino"] = new SelectList(_context.DestinoUser, "Id_Destino", "Cidade", novoUser.DestinoUserId_Destino);
            return View(novoUser);
        }

        // GET: NovoUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var novoUser = await _context.NovoUsers
                .Include(n => n.DestinoUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (novoUser == null)
            {
                return NotFound();
            }

            return View(novoUser);
        }

        // POST: NovoUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var novoUser = await _context.NovoUsers.FindAsync(id);
            _context.NovoUsers.Remove(novoUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NovoUserExists(int id)
        {
            return _context.NovoUsers.Any(e => e.Id == id);
        }
    }
}
