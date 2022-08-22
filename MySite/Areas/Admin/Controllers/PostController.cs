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

    public class PostController : Controller
    {
        private readonly ProductionContext _context;

        public PostController(ProductionContext context)
        {
            _context = context;
        }

        // GET: Post
        public async Task<IActionResult> Index()
        {
            return View(await _context.Posts.ToListAsync());
        }


        // GET: Post/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var entity = id == default ? new Post() : await _context.Posts.FirstOrDefaultAsync(x => x.IdPost == id);
            return View(entity);
        }

        // POST: Post/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPost,Name")] Post post)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(post);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    if (!PostExists(post.IdPost))
                    {
                        new Post();
                    }
                    else
                    {
                        TempData["Message"] = "Выбранная должность не может быть изменена";
                    }
                }
                return RedirectToAction(nameof(Index));
            }          
            return View(post);
        }

        

        // POST: Post/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var post = await _context.Posts.FindAsync(id);
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                TempData["Message"] = "Выбранная должность не может быть удалена";
            }
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.IdPost == id);
        }
    }
}
