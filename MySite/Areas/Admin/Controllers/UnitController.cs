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

    public class UnitController : Controller
    {
        private readonly ProductionContext _context;

        public UnitController(ProductionContext context)
        {
            _context = context;
        }

        // GET: Unit
        public async Task<IActionResult> Index()
        {
            return View(await _context.Units.ToListAsync());
        }

        
        // GET: Unit/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var entity = id == default ? new Unit() : await _context.Units.FirstOrDefaultAsync(x => x.IdUnit == id);
            return View(entity);
        }

        // POST: Unit/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUnit,Name")] Unit unit)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    if (!UnitExists(unit.IdUnit))
                    {
                        new Unit();
                    }
                    else
                    {
                        TempData["Message"] = "Запись не может быть изменена";

                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(unit);
        }


        // POST: Unit/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var unit = await _context.Units.FindAsync(id);
                _context.Units.Remove(unit);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                TempData["Message"] = "Запись не может быть удалена";
            }
            return RedirectToAction(nameof(Index));
        }

        private bool UnitExists(int id)
        {
            return _context.Units.Any(e => e.IdUnit == id);
        }
    }
}
