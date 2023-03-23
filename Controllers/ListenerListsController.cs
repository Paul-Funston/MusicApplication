using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicApplication.Data;
using MusicApplication.Models;

namespace MusicApplication.Controllers
{
    public class ListenerListsController : Controller
    {
        private readonly MusicApplicationContext _context;

        public ListenerListsController(MusicApplicationContext context)
        {
            _context = context;
        }

        // GET: ListenerLists
        public async Task<IActionResult> Index()
        {
              return _context.ListenerLists != null ? 
                          View(await _context.ListenerLists.ToListAsync()) :
                          Problem("Entity set 'MusicApplicationContext.ListenerLists'  is null.");
        }

        // GET: ListenerLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ListenerLists == null)
            {
                return NotFound();
            }

            ListenerList? listenerList = await _context.ListenerLists
                .Include(ll => ll.ListenerListPodcasts).ThenInclude(ll => ll.Podcast)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listenerList == null)
            {
                return NotFound();
            }

            return View(listenerList);
        }

        // GET: ListenerLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ListenerLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] ListenerList listenerList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listenerList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(listenerList);
        }

        // GET: ListenerLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ListenerLists == null)
            {
                return NotFound();
            }

            var listenerList = await _context.ListenerLists.FindAsync(id);
            if (listenerList == null)
            {
                return NotFound();
            }
            return View(listenerList);
        }

        // POST: ListenerLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] ListenerList listenerList)
        {
            if (id != listenerList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listenerList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListenerListExists(listenerList.Id))
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
            return View(listenerList);
        }

        // GET: ListenerLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ListenerLists == null)
            {
                return NotFound();
            }

            var listenerList = await _context.ListenerLists
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listenerList == null)
            {
                return NotFound();
            }

            return View(listenerList);
        }

        // POST: ListenerLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ListenerLists == null)
            {
                return Problem("Entity set 'MusicApplicationContext.ListenerLists'  is null.");
            }
            var listenerList = await _context.ListenerLists.FindAsync(id);
            if (listenerList != null)
            {
                _context.ListenerLists.Remove(listenerList);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListenerListExists(int id)
        {
          return (_context.ListenerLists?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
