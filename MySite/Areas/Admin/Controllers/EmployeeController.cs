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

    public class EmployeeController : Controller
    {

        //private readonly DataManager dataManager;
        //public EmployeeController(DataManager dataManager)
        //{
        //    this.dataManager = dataManager;
        //}
        //[TempData]
        //public string Message { get; set; }

        private readonly ProductionContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;


        public EmployeeController(ProductionContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;

        }

        // GET: EmployeeController

        public async Task<IActionResult> Index()
        {
            var productionContext = _context.Employees.Include(e => e.PostNavigation);
            return View(await productionContext.ToListAsync());
        }


        



        // GET: EmployeeController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            var entity = id == default ? new Employee() : await _context.Employees.FirstOrDefaultAsync(x => x.IdEmpl == id);
            ViewData["Post"] = new SelectList(_context.Posts, "IdPost", "Name", entity.Post); 
            return View(entity);
        }



        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEmpl,Name,Post,Salary,Address,Phone,Premium")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    if (!EmployeeExists(employee.IdEmpl))
                    {
                        new Employee();
                    }
                    else
                    {
                        TempData["Message"] = "Выбранный сотрудник не может быть изменен";

                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Post"] = new SelectList(_context.Posts, "IdPost", "Name", employee.Post);
            return View(employee);
        }


        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var employee = await _context.Employees.FindAsync(id);
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
        
               TempData["Message"] = "Выбранный сотрудник не может быть удален";
            }
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.IdEmpl == id);
        }
        public IActionResult Salary(int? id)
        {
            try
            {

                var param = new Microsoft.Data.SqlClient.SqlParameter
                {
                    ParameterName = "@id",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Input,
                    Size = 50
                };
                param.Value = id;
                _context.Database.ExecuteSqlRaw("dbo.Calc_SalaryID @id", param);
                TempData["Message"] = "Зарплата расчитана и добавлена в Затраты";// вывести не красным цветом

            }
            catch (Exception)
            {
                TempData["Message"] = "Недостаточно средств в бюджете";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
