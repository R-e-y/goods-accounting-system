using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MySite.Domain.Entities;

namespace MySite.Controllers
{
    [Authorize(Roles = "Manager, Admin")]

    public class ManufactureController : Controller
    {
        private readonly ProductionContext _context;

        public ManufactureController(ProductionContext context)
        {
            _context = context;
        }

        // GET: Manufacture
        public async Task<IActionResult> Index()
        {
            var productionContext = _context.Manufactures.Include(m => m.EmployeeNavigation).Include(m => m.ProductNavigation);
            return View(await productionContext.ToListAsync());
        }



        // GET: Manufacture/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            var entity = id == default ? new Manufacture() : await _context.Manufactures.FirstOrDefaultAsync(x => x.IdMan == id);
            ViewData["Employee"] = new SelectList(_context.Employees, "IdEmpl", "Name", entity.Employee);
            ViewData["Product"] = new SelectList(_context.FinishedProds, "IdProd", "Name", entity.Product);
            return View(entity);
        }


        // POST: ManufactureController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMan,Product,Amount,Date,Employee")] Manufacture manufacture)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(manufacture);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    if (!ManufactureExists(manufacture.IdMan))
                    {
                        new Manufacture();
                    }
                    else
                    {
                        TempData["Message"] = "Недостаточное количество сырья";
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Employee"] = new SelectList(_context.Employees, "IdEmpl", "Name", manufacture.Employee);
            ViewData["Product"] = new SelectList(_context.FinishedProds, "IdProd", "Name", manufacture.Product);
            return View(manufacture);
        }

    
        

        // POST: Manufacture/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try {
            var manufacture = await _context.Manufactures.FindAsync(id);
            _context.Manufactures.Remove(manufacture);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                TempData["Message"] = "Недостаточное количество изготовленной продукции";
            }
            return RedirectToAction(nameof(Index));

        }

        private bool ManufactureExists(int id)
        {
            return _context.Manufactures.Any(e => e.IdMan == id);
        }

        public IActionResult MList()
        {
            _context.Database.ExecuteSqlRaw("dbo.MList");
            return RedirectToAction(nameof(Index));
        }
    }
}
