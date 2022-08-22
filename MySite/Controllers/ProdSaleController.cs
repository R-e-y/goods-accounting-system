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

    public class ProdSaleController : Controller
    {
        private readonly ProductionContext _context;

        public ProdSaleController(ProductionContext context)
        {
            _context = context;
        }

        // GET: ProdSale
        public async Task<IActionResult> Index()
        {
            var productionContext = _context.ProdSales.Include(p => p.EmployeeNavigation).Include(p => p.ProductNavigation);
            return View(await productionContext.ToListAsync());
        }

       

        // GET: ProdSale/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            var entity = id == default ? new ProdSale() : await _context.ProdSales.FirstOrDefaultAsync(x => x.IdSale == id);
            ViewData["Employee"] = new SelectList(_context.Employees, "IdEmpl", "Name", entity.Employee);
            ViewData["Product"] = new SelectList(_context.FinishedProds, "IdProd", "Name", entity.Product);
            return View(entity);
        }

        // POST: ProdSale/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSale,Product,Amount,Sum,Date,Employee")] ProdSale prodSale)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prodSale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {

                    //if (!ProdSaleExists(prodSale.IdSale))
                    //{
                    //    new ProdSale();
                    //}
                    //else
                    //{
                    //    TempData["Message"] = "Недостаточное количество изготовленной продукции";
                    //}
                    TempData["Message"] = "Недостаточное количество изготовленной продукции";
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Employee"] = new SelectList(_context.Employees, "IdEmpl", "Name", prodSale.Employee);
            ViewData["Product"] = new SelectList(_context.FinishedProds, "IdProd", "Name", prodSale.Product);
            return View(prodSale);
        }

        

        // POST: ProdSale/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var prodSale = await _context.ProdSales.FindAsync(id);
                _context.ProdSales.Remove(prodSale);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                TempData["Message"] = "Недостаточно средств в бюджете";
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ProdSaleExists(int id)
        {
            return _context.ProdSales.Any(e => e.IdSale == id);
        }

        public IActionResult PSList()
        {
            _context.Database.ExecuteSqlRaw("dbo.PSList");
            return RedirectToAction(nameof(Index));
        }
    }
}
