using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using learning1.Models;

namespace learning1.Views
{
    public class EmailLogsController : Controller
    {
        private readonly DbHalloDocContext _context;

        public EmailLogsController(DbHalloDocContext context)
        {
            _context = context;
        }

        // GET: EmailLogs
        public async Task<IActionResult> Index()
        {
              return _context.EmailLogs != null ? 
                          View(await _context.EmailLogs.ToListAsync()) :
                          Problem("Entity set 'DbHalloDocContext.EmailLogs'  is null.");
        }

        // GET: EmailLogs/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null || _context.EmailLogs == null)
            {
                return NotFound();
            }

            var emailLog = await _context.EmailLogs
                .FirstOrDefaultAsync(m => m.EmailLogId == id);
            if (emailLog == null)
            {
                return NotFound();
            }

            return View(emailLog);
        }

        // GET: EmailLogs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmailLogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmailLogId,EmailTemplate,SubjectName,EmailId,ConfirmationNumber,FilePath,RoleId,RequestId,AdminId,PhysicianId,CreateDate,SentDate,IsEmailSent,SentTries,Action")] EmailLog emailLog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emailLog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(emailLog);
        }

        // GET: EmailLogs/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null || _context.EmailLogs == null)
            {
                return NotFound();
            }

            var emailLog = await _context.EmailLogs.FindAsync(id);
            if (emailLog == null)
            {
                return NotFound();
            }
            return View(emailLog);
        }

        // POST: EmailLogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("EmailLogId,EmailTemplate,SubjectName,EmailId,ConfirmationNumber,FilePath,RoleId,RequestId,AdminId,PhysicianId,CreateDate,SentDate,IsEmailSent,SentTries,Action")] EmailLog emailLog)
        {
            if (id != emailLog.EmailLogId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emailLog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmailLogExists(emailLog.EmailLogId))
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
            return View(emailLog);
        }

        // GET: EmailLogs/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null || _context.EmailLogs == null)
            {
                return NotFound();
            }

            var emailLog = await _context.EmailLogs
                .FirstOrDefaultAsync(m => m.EmailLogId == id);
            if (emailLog == null)
            {
                return NotFound();
            }

            return View(emailLog);
        }

        // POST: EmailLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            if (_context.EmailLogs == null)
            {
                return Problem("Entity set 'DbHalloDocContext.EmailLogs'  is null.");
            }
            var emailLog = await _context.EmailLogs.FindAsync(id);
            if (emailLog != null)
            {
                _context.EmailLogs.Remove(emailLog);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmailLogExists(decimal id)
        {
          return (_context.EmailLogs?.Any(e => e.EmailLogId == id)).GetValueOrDefault();
        }
    }
}
