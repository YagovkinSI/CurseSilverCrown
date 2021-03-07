using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CurseSilverCrown.Web.Data;
using CurseSilverCrown.Web.Models;

namespace CurseSilverCrown.Web.Controllers
{
    public class User_ProvinceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public User_ProvinceController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: User_Province
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.User_Province.Include(u => u.Province).Include(u => u.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: User_Province/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user_Province = await _context.User_Province
                .Include(u => u.Province)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.ProvinceId == id);
            if (user_Province == null)
            {
                return NotFound();
            }

            return View(user_Province);
        }

        // GET: User_Province/Create
        public IActionResult Create()
        {
            ViewData["ProvinceId"] = new SelectList(_context.Provinces, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: User_Province/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProvinceId,UserId")] User_Province user_Province)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user_Province);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProvinceId"] = new SelectList(_context.Provinces, "Id", "Id", user_Province.ProvinceId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", user_Province.UserId);
            return View(user_Province);
        }

        // GET: User_Province/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user_Province = await _context.User_Province.FindAsync(id);
            if (user_Province == null)
            {
                return NotFound();
            }
            ViewData["ProvinceId"] = new SelectList(_context.Provinces, "Id", "Id", user_Province.ProvinceId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", user_Province.UserId);
            return View(user_Province);
        }

        // POST: User_Province/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProvinceId,UserId")] User_Province user_Province)
        {
            if (id != user_Province.ProvinceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user_Province);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!User_ProvinceExists(user_Province.ProvinceId))
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
            ViewData["ProvinceId"] = new SelectList(_context.Provinces, "Id", "Id", user_Province.ProvinceId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", user_Province.UserId);
            return View(user_Province);
        }

        // GET: User_Province/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user_Province = await _context.User_Province
                .Include(u => u.Province)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.ProvinceId == id);
            if (user_Province == null)
            {
                return NotFound();
            }

            return View(user_Province);
        }

        // POST: User_Province/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user_Province = await _context.User_Province.FindAsync(id);
            _context.User_Province.Remove(user_Province);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool User_ProvinceExists(int id)
        {
            return _context.User_Province.Any(e => e.ProvinceId == id);
        }
    }
}
