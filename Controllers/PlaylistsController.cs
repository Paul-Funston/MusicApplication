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
    public class PlaylistsController : Controller
    {
        private readonly MusicApplicationContext _context;

        public PlaylistsController(MusicApplicationContext context)
        {
            _context = context;
        }

        // GET: Playlists
        public async Task<IActionResult> Index()
        {
            return View(await _context.Playlists.ToListAsync());
        }

        // GET: Playlists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Playlists == null)
            {
                return NotFound();
            }

            Playlist? playlist = await _context.Playlists
                .Include(p => p.PlaylistSongs).ThenInclude(ps => ps.Song)
                .ThenInclude(s => s.Album)
                .Include(p => p.PlaylistSongs).ThenInclude(ps => ps.Song)
                .ThenInclude(s => s.SongContributers)
                .ThenInclude(sc => sc.Artist)
                .FirstOrDefaultAsync(m => m.Id == id);


            if (playlist == null)
            {
                return NotFound();
            }

            ViewBag.SongCount = playlist.PlaylistSongs.Count;
            int playlistDurationInSeconds = playlist.PlaylistSongs.Sum(ps => ps.Song.DurationSeconds);
            TimeSpan ts = TimeSpan.FromSeconds(playlistDurationInSeconds);
            ViewBag.Duration = ts.ToString("c");
            ViewBag.Counter = 1;
            return View(playlist);
        }

        // GET: Playlists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Playlists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Playlist playlist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(playlist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(playlist);
        }

        // GET: Playlists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Playlists == null)
            {
                return NotFound();
            }

            var playlist = await _context.Playlists.FindAsync(id);
            if (playlist == null)
            {
                return NotFound();
            }
            return View(playlist);
        }

        // POST: Playlists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Playlist playlist)
        {
            if (id != playlist.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(playlist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlaylistExists(playlist.Id))
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
            return View(playlist);
        }

        // GET: Playlists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Playlists == null)
            {
                return NotFound();
            }

            var playlist = await _context.Playlists
                .FirstOrDefaultAsync(m => m.Id == id);
            if (playlist == null)
            {
                return NotFound();
            }

            return View(playlist);
        }

        // POST: Playlists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Playlists == null)
            {
                return Problem("Entity set 'MusicApplicationContext.Playlists'  is null.");
            }
            var playlist = await _context.Playlists.FindAsync(id);
            if (playlist != null)
            {
                _context.Playlists.Remove(playlist);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> RemoveSong(int? psId, int? playlistId, int? songId )
        {
            if (_context.PlaylistSongs == null)
            {
                return Problem("Entity set 'MusicApplicationContext.Playlists'  is null.");
            }

            PlaylistSong? playlistSong = await _context.PlaylistSongs.FindAsync(psId);

            if(playlistSong != null && playlistSong.PlaylistId == playlistId && playlistSong.SongId == songId)
            {
                _context.PlaylistSongs.Remove(playlistSong);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Details", new {id= playlistId});


        }
        private bool PlaylistExists(int id)
        {
            return _context.Playlists.Any(e => e.Id == id);
        }
    }
}
