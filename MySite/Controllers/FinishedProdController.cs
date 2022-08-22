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
using Microsoft.AspNetCore.Authorization;

namespace MySite.Controllers
{
    [Authorize(Roles = "Manager, Technologist, Admin")]


    public class FinishedProdController : Controller
    {
        private readonly ProductionContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;


        public FinishedProdController(ProductionContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;

        }
        // GET: FinishedProdController
        public async Task<IActionResult> Index()
        {
            var productionContext = _context.FinishedProds.Include(f => f.UnitNavigation);
            return View(await productionContext.ToListAsync());
        }

        // GET: FinishedProdController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FinishedProdController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FinishedProdController/Create
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

        // GET: FinishedProdController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var entity = id == default ? new FinishedProd() : await _context.FinishedProds.FirstOrDefaultAsync(x => x.IdProd == id);
            ViewData["Unit"] = new SelectList(_context.Units, "IdUnit", "Name", entity.Unit);
            return View(entity);
        }

        // POST: FinishedProdController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProd,Name,Unit,Price,Amount,Markup")] FinishedProd finishedProd)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(finishedProd);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    if (!FinishedProdExists(finishedProd.IdProd))
                    {
                        new FinishedProd();
                    }
                    else
                    {
                        ViewData["Message"] = "Изделие не может быть изменено";
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Unit"] = new SelectList(_context.Units, "IdUnit", "Name", finishedProd.Unit);
            return View(finishedProd);
        }

        // GET: FinishedProdController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FinishedProdController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var finishedProd = await _context.FinishedProds.FindAsync(id);
                _context.FinishedProds.Remove(finishedProd);
                await _context.SaveChangesAsync();
            }
            catch
            {
                ViewData["Message"] = "Изделие не может быть удалено";
            }
            return RedirectToAction(nameof(Index));
        }
        private bool FinishedProdExists(int id)
        {
            return _context.FinishedProds.Any(e => e.IdProd == id);
        }

        public IActionResult FPList()
        {
            _context.Database.ExecuteSqlRaw("dbo.FPList");
            return RedirectToAction(nameof(Index));
        }
    }
}
