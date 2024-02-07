using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using learning1.Models;

namespace learning1.Controllers
{
    public class AdminsController : Controller
    {
        private readonly DbHalloDocContext _context;

        public AdminsController(DbHalloDocContext context)
        {
            _context = context;
        }

        // GET: Admins
        public async Task<IActionResult> Index()
        {
            var dbHalloDocContext = _context.Admins.Include(a => a.AspNetUser).Include(a => a.CreatedByNavigation).Include(a => a.ModifiedByNavigation);
            return View(await dbHalloDocContext.ToListAsync());
        }

        // GET: Admins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Admins == null)
            {
                return NotFound();
            }

            var admin = await _context.Admins
                .Include(a => a.AspNetUser)
                .Include(a => a.CreatedByNavigation)
                .Include(a => a.ModifiedByNavigation)
                .FirstOrDefaultAsync(m => m.AdminId == id);
            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }

        // GET: Admins/Create
        public IActionResult Create()
        {
            ViewData["AspNetUserId"] = new SelectList(_context.AspNetUsers, "Id", "Id");
            ViewData["CreatedBy"] = new SelectList(_context.AspNetUsers, "Id", "Id");
            ViewData["ModifiedBy"] = new SelectList(_context.AspNetUsers, "Id", "Id");
            return View();
        }

        // POST: Admins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdminId,AspNetUserId,FirstName,LastName,Email,Mobile,Address1,Address2,City,RegionId,Zip,AltPhone,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Status,IsDeleted,RoleId")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(admin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AspNetUserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", admin.AspNetUserId);
            ViewData["CreatedBy"] = new SelectList(_context.AspNetUsers, "Id", "Id", admin.CreatedBy);
            ViewData["ModifiedBy"] = new SelectList(_context.AspNetUsers, "Id", "Id", admin.ModifiedBy);
            return View(admin);
        }

        // GET: Admins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Admins == null)
            {
                return NotFound();
            }

            var admin = await _context.Admins.FindAsync(id);
            if (admin == null)
            {
                return NotFound();
            }
            ViewData["AspNetUserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", admin.AspNetUserId);
            ViewData["CreatedBy"] = new SelectList(_context.AspNetUsers, "Id", "Id", admin.CreatedBy);
            ViewData["ModifiedBy"] = new SelectList(_context.AspNetUsers, "Id", "Id", admin.ModifiedBy);
            return View(admin);
        }

        // POST: Admins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AdminId,AspNetUserId,FirstName,LastName,Email,Mobile,Address1,Address2,City,RegionId,Zip,AltPhone,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Status,IsDeleted,RoleId")] Admin admin)
        {
            if (id != admin.AdminId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(admin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminExists(admin.AdminId))
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
            ViewData["AspNetUserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", admin.AspNetUserId);
            ViewData["CreatedBy"] = new SelectList(_context.AspNetUsers, "Id", "Id", admin.CreatedBy);
            ViewData["ModifiedBy"] = new SelectList(_context.AspNetUsers, "Id", "Id", admin.ModifiedBy);
            return View(admin);
        }

        // GET: Admins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Admins == null)
            {
                return NotFound();
            }

            var admin = await _context.Admins
                .Include(a => a.AspNetUser)
                .Include(a => a.CreatedByNavigation)
                .Include(a => a.ModifiedByNavigation)
                .FirstOrDefaultAsync(m => m.AdminId == id);
            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }

        // POST: Admins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Admins == null)
            {
                return Problem("Entity set 'DbHalloDocContext.Admins'  is null.");
            }
            var admin = await _context.Admins.FindAsync(id);
            if (admin != null)
            {
                _context.Admins.Remove(admin);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdminExists(int id)
        {
          return (_context.Admins?.Any(e => e.AdminId == id)).GetValueOrDefault();
        }
    }
}
