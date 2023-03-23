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
    public class AlbumsController : Controller
    {
        private readonly MusicApplicationContext _context;

        public AlbumsController(MusicApplicationContext context)
        {
            _context = context;
        }

        // GET: Albums
        public async Task<IActionResult> Index(int? id)
        {
            var context = _context.Albums
                  .Include(a => a.Songs)
                  .ThenInclude(s => s.MediaContributers)
                  .ThenInclude(sc => sc.Artist);
                  

            if (id != null && id > 0)
            {
                return View(await context.Where(a =>
                    a.Songs.Any(s => s.MediaContributers.Any
                        (sc => sc.ArtistId == id))).ToListAsync());
            }
            
            
              return View(await context.ToListAsync());
        }

      

    }
}
