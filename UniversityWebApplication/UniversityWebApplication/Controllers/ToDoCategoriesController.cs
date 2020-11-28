using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniversityWebApplication.Models;

namespace UniversityWebApplication.Controllers
{
    public class ToDoCategoriesController : Controller
    {
        private readonly AppDbContext _context;

        public ToDoCategoriesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ToDoCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.ToDoCategory.ToListAsync());
        }

        // GET: ToDoCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toDoCategory = await _context.ToDoCategory
                .FirstOrDefaultAsync(m => m.Category_Id == id);
            if (toDoCategory == null)
            {
                return NotFound();
            }

            return View(toDoCategory);
        }

        // GET: ToDoCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ToDoCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Category_Id,CategoryName")] ToDoCategory toDoCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(toDoCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(toDoCategory);
        }

        // GET: ToDoCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toDoCategory = await _context.ToDoCategory.FindAsync(id);
            if (toDoCategory == null)
            {
                return NotFound();
            }
            return View(toDoCategory);
        }

        // POST: ToDoCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Category_Id,CategoryName")] ToDoCategory toDoCategory)
        {
            if (id != toDoCategory.Category_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(toDoCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToDoCategoryExists(toDoCategory.Category_Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(toDoCategory);
        }

        // GET: ToDoCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toDoCategory = await _context.ToDoCategory
                .FirstOrDefaultAsync(m => m.Category_Id == id);
            if (toDoCategory == null)
            {
                return NotFound();
            }

            return View(toDoCategory);
        }

        // POST: ToDoCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var toDoCategory = await _context.ToDoCategory.FindAsync(id);
            _context.ToDoCategory.Remove(toDoCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ToDoCategoryExists(int id)
        {
            return _context.ToDoCategory.Any(e => e.Category_Id == id);
        }
    }
}
