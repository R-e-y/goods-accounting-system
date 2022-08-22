using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using MySite.Domain;
using MySite.Domain.Entities;
using MySite.Service;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MySite.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class RawPurchaseController : Controller
    {
        private readonly ProductionContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;


        public RawPurchaseController(ProductionContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;

        }
        // GET: RawPurchase
        public async Task<IActionResult> Index()
        {
            var productionContext = _context.RawPurchases.Include(r => r.EmployeeNavigation).Include(r => r.RawNavigation).Include(r => r.UnitNavigation);
            return View(await productionContext.ToListAsync());
        }

        // GET: RawPurchase/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RawPurchase/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RawPurchase/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RawPurchase/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var entity = id == default ? new RawPurchase() : await _context.RawPurchases.FirstOrDefaultAsync(x => x.IdPur == id);
            ViewData["Raw"] = new SelectList(_context.Raws, "IdRaw", "Name", entity.Raw);
            ViewData["Unit"] = new SelectList(_context.Units, "IdUnit", "Name", entity.Unit);
            ViewData["Employee"] = new SelectList(_context.Employees, "IdEmpl", "Name", entity.Employee);
            return View(entity);
        }

        // POST: RawPurchase/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPur,Raw,Amount,Sum,Unit,Date,Employee")] RawPurchase rawPurchase)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rawPurchase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    if (!RawPurchaseExists(rawPurchase.IdPur))
                    {
                        new RawPurchase();
                    }
                    else
                    {
                        TempData["Message"] = "Недостаточно средств в бюджете";
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Raw"] = new SelectList(_context.Raws, "IdRaw", "Name", rawPurchase.Raw);
            ViewData["Unit"] = new SelectList(_context.Units, "IdUnit", "Name", rawPurchase.Unit);
            ViewData["Employee"] = new SelectList(_context.Employees, "IdEmpl", "Name", rawPurchase.Employee);
            return View(rawPurchase);
        }

        // GET: RawPurchase/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RawPurchase/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var rawPurchase = await _context.RawPurchases.FindAsync(id);
                _context.RawPurchases.Remove(rawPurchase);
                await _context.SaveChangesAsync();      
            }
            catch
            {
                ViewData["Message"] = "Недостаточное количество сырья";
            }
            return RedirectToAction(nameof(Index));
        }
       
        private bool RawPurchaseExists(int id)
        {
            return _context.RawPurchases.Any(e => e.IdPur == id);
        }
    }
}
