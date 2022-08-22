using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MySite.Domain.Entities;

namespace MySite.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class RawController : Controller
    {
        private readonly ProductionContext _context;

        public RawController(ProductionContext context)
        {
            _context = context;
        }

        // GET: Raw
        public async Task<IActionResult> Index()
        {
            var productionContext = _context.Raws.Include(r => r.UnitNavigation);
            return View(await productionContext.ToListAsync());
        }

        

        // GET: Raw/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var entity = id == default ? new Raw() : await _context.Raws.FirstOrDefaultAsync(x => x.IdRaw == id);
            ViewData["Unit"] = new SelectList(_context.Units, "IdUnit", "Name", entity.Unit);
            return View(entity);
        }

        // POST: Raw/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRaw,Name,Unit,Sum,Amount")] Raw raw)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(raw);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    if (!RawExists(raw.IdRaw))
                    {
                        new Raw();
                    }
                    else
                    {
                        TempData["Message"] = "Запись не может быть изменена";
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Unit"] = new SelectList(_context.Units, "IdUnit", "Name", raw.Unit);
            return View(raw);
        }

       

        // POST: Raw/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var raw = await _context.Raws.FindAsync(id);
                _context.Raws.Remove(raw);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                TempData["Message"] = "Сырье используется в произвостве";
            }
            return RedirectToAction(nameof(Index));
        }

        private bool RawExists(int id)
        {
            return _context.Raws.Any(e => e.IdRaw == id);
        }
    }
}
