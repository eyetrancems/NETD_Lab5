using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NETD_Lab5.Models;

namespace NETD_Lab5.Controllers
{
    public class DvdsController : Controller
    {
        private readonly BookContext _context;

        public DvdsController(BookContext context)
        {
            _context = context;
        }

        // GET: Dvds
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dvds.ToListAsync());
        }

        // GET: Dvds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dvd = await _context.Dvds
                .FirstOrDefaultAsync(m => m.dvdID == id);
            if (dvd == null)
            {
                return NotFound();
            }

            return View(dvd);
        }

        // GET: Dvds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dvds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("dvdID,title,director,actor,studio,copies,ASIN")] Dvd dvd)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dvd);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dvd);
        }

        // GET: Dvds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dvd = await _context.Dvds.FindAsync(id);
            if (dvd == null)
            {
                return NotFound();
            }
            return View(dvd);
        }

        // POST: Dvds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("dvdID,title,director,actor,studio,copies,ASIN")] Dvd dvd)
        {
            if (id != dvd.dvdID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dvd);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DvdExists(dvd.dvdID))
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
            return View(dvd);
        }

        // GET: Dvds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dvd = await _context.Dvds
                .FirstOrDefaultAsync(m => m.dvdID == id);
            if (dvd == null)
            {
                return NotFound();
            }

            return View(dvd);
        }

        // POST: Dvds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dvd = await _context.Dvds.FindAsync(id);
            _context.Dvds.Remove(dvd);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DvdExists(int id)
        {
            return _context.Dvds.Any(e => e.dvdID == id);
        }
    }
}
