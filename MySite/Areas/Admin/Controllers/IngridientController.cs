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
    public class IngridientController : Controller
    {
        private readonly ProductionContext _context;

        public IngridientController(ProductionContext context)
        {
            _context = context;
        }

        // GET: Ingredient
        public async Task<IActionResult> Index()
        {
            var productionContext = _context.Ingredients.Include(i => i.ProductNavigation).Include(i => i.RawNavigation);
            return View(await productionContext.ToListAsync());
        }

       

        // GET: Ingredient/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            var entity = id == default ? new Ingridient() : await _context.Ingredients.FirstOrDefaultAsync(x => x.IdIngr == id);
            ViewData["Product"] = new SelectList(_context.FinishedProds, "IdProd", "Name", entity.Product);
            ViewData["Raw"] = new SelectList(_context.Raws, "IdRaw", "Name", entity.Raw);
            return View(entity);
        }

        // POST: Ingredient/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdIngr,Product,Raw,Amount")] Ingridient ingredient)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ingredient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    if (!IngredientExists(ingredient.IdIngr))
                    {
                        new Ingridient();
                    }
                    else
                    {
                        TempData["Message"] = "Запись не может быть изменена";
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Product"] = new SelectList(_context.FinishedProds, "IdProd", "Name", ingredient.Product);
            ViewData["Raw"] = new SelectList(_context.Raws, "IdRaw", "Name", ingredient.Raw);
            return View(ingredient);
        }



        // POST: Ingredient/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var ingredient = await _context.Ingredients.FindAsync(id);
                _context.Ingredients.Remove(ingredient);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                TempData["Message"] = "Запись не может быть удалена";
            }
            return RedirectToAction(nameof(Index));
        }

        private bool IngredientExists(int id)
        {
            return _context.Ingredients.Any(e => e.IdIngr == id);
        }
    }
}
