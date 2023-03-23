using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicApplication.Data;
using MusicApplication.Models;
using MusicApplication.Models.ViewModel;

namespace MusicApplication.Controllers
{
    public class PodcastsController : Controller
    {
        private readonly MusicApplicationContext _context;

        public PodcastsController(MusicApplicationContext context)
        {
            _context = context;
        }

        // GET: Podcasts
        public async Task<IActionResult> Index(int? id)
        {
            var podcasts = _context.Podcasts
                .Include(p => p.ListenerListPodcasts).ThenInclude(ll => ll.ListenerList)
                .Include(p => p.Cast).ThenInclude(pc => pc.Artist);


            if(id.HasValue && id.Value > 0)
            {
                return podcasts != null ?
                    View(await podcasts.Where(p => p.ListenerListPodcasts.Any(llc => llc.ListenerListId == id)).ToListAsync()) :
                    Problem("Entity set 'MusicApplicationContext.Podcasts'  is null.");
            }

              return _context.Podcasts != null ? 
                          View(await _context.Podcasts.ToListAsync()) :
                          Problem("Entity set 'MusicApplicationContext.Podcasts'  is null.");
        }

        // GET: Podcasts/Details/5
        public async Task<IActionResult> Details(int? id, string? orderDesc)
        {
            if (id == null || _context.Podcasts == null)
            {
                return NotFound();
            }

            Podcast? podcast = await _context.Podcasts
                .Include(p => p.Episodes).ThenInclude(e => e.MediaContributers).ThenInclude(mc => mc.Artist)
                .Include(p => p.Cast).ThenInclude(pc => pc.Artist)
                .FirstOrDefaultAsync(m => m.Id == id);
                
            if (podcast == null)
            {
                return NotFound();
            }

            ViewBag.OrderDesc = orderDesc == "t";

            return View(podcast);
        }



        
    }
}
