using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MySite.Domain.Entities;

namespace MySite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BudgetController : Controller
    {    
        private readonly ProductionContext _context;

        public BudgetController(ProductionContext context)
        {
            _context = context;
        }

        // GET: Budget
        public async Task<IActionResult> Index()
        {
            return View(await _context.Budgets.ToListAsync());
        }

       

        // GET: Budget/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var entity = id == default ? new Budget() : await _context.Budgets.FirstOrDefaultAsync(x => x.IdBudget == id);
            return View(entity);
        }

        // POST: Budget/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdBudget,Sum")] Budget budget)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(budget);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    if (!BudgetExists(budget.IdBudget))
                    {
                        new Budget();
                    }
                    else
                    {
                        TempData["Message"] = "Запись не может быть изменена";
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(budget);
        }


        // POST: Budget/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var budget = await _context.Budgets.FindAsync(id);
                _context.Budgets.Remove(budget);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                TempData["Message"] = "Запись не может быть удалена";
            }
            return RedirectToAction(nameof(Index));
        }

        private bool BudgetExists(int id)
        {
            return _context.Budgets.Any(e => e.IdBudget == id);
        }
    }
}
