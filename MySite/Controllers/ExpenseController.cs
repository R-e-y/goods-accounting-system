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
    [Authorize(Roles = "Accountant, Admin")]

    public class ExpenseController : Controller
    {
        //private readonly DataManager dataManager;
        //public ExpenseController( DataManager dataManager)
        //{
        //    this.dataManager = dataManager;
        //}
        // GET: ExpanseController
        private readonly ProductionContext _context;
        private readonly IEnumerable<SelectListItem> Values;
        
public ExpenseController (ProductionContext context)
        {
            _context = context;
            Values = new[]
            {
        new SelectListItem { Value = "Налоги", Text = "Налоги" },
        new SelectListItem { Value = "Аренда", Text = "Аренда" },

            };
        }

        public async Task<IActionResult> Index()
        {
           
            var productionContext = _context.Expenses.Include(e => e.EmployeeNavigation);
            return View(await productionContext.ToListAsync());

        }


        // GET: ExpanseController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            var entity = id == default ? new Expense() : await _context.Expenses.FirstOrDefaultAsync(x => x.IdExp == id);
            ViewData["Name"] = Values;
            ViewData["Employee"] = new SelectList(_context.Employees, "IdEmpl", "Name", entity.Employee);

            return View(entity);
        }

        // POST: ExpanseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdExp, Name, Sum, Date, Employee")] Expense expense)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expense);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    if (!ExpenseExists(expense.IdExp))
                    {
                        new Expense();
                    }
                    else
                    {
                        TempData["Message"] = "Не достаточно средств в бюджете";

                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Employee"] = new SelectList(_context.Employees, "IdEmpl", "Name", expense.Employee);
            ViewData["Name"] = Values;
            return View(expense);
        }

        

        // POST: ExpanseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var expense = await _context.Expenses.FindAsync(id);
                _context.Expenses.Remove(expense);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {

                TempData["Message"] = "Запись не может быть удалена";
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ExpenseExists(int id)
        {
            return _context.Expenses.Any(e => e.IdExp == id);
        }

       
        public IActionResult Exp()
        {
            try
            {
                _context.Database.ExecuteSqlRaw("dbo.Calc_Expenses");
            }
            catch (Exception)
            {

                TempData["Message"] = "Затраты за текущий месяц уже добавлены";
            }
            return RedirectToAction(nameof(Index));

        }

    }
}
