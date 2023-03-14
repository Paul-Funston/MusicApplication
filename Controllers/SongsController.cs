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
    public class SongsController : Controller
    {
        private readonly MusicApplicationContext _context;

        public SongsController(MusicApplicationContext context)
        {
            _context = context;
        }

        // GET: Songs
        public async Task<IActionResult> Index(int? id)
        {
            var musicApplicationContext = _context.Songs
                .Include(s => s.Album)
                .Include(s => s.SongContributers)
                .ThenInclude(sc => sc.Artist);


            if(id.HasValue && id > 0)
            {
                return View(await musicApplicationContext.Where(s =>
                    s.Album.Id == id).ToListAsync());
            }


            return View(await musicApplicationContext.ToListAsync());
        }

        // GET: Songs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Songs == null)
            {
                return NotFound();
            }

            var song = await _context.Songs
                .Include(s => s.Album)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (song == null)
            {
                return NotFound();
            }

            return View(song);
        }

    }
}
