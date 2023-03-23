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


        [HttpGet]
        public IActionResult AddToListenerList(int id)
        {
            Podcast? podcast = _context.Podcasts.FirstOrDefault(p => p.Id == id);
            if (podcast == null) { return NotFound(); }
            AddToListenerListVM vm = new AddToListenerListVM(_context.ListenerLists.Include(ll => ll.ListenerListPodcasts), id, podcast.Title);
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> AddToListenerList([Bind("PodcastId,ListenerListId,PodcastTitle")] AddToListenerListVM vm)
        {
            if (vm.ListenerListId != null && vm.PodcastId != null)
            {
                if (!_context.ListenerListPodcasts.Any(llp => llp.ListenerListId == vm.ListenerListId && llp.PodcastId == vm.PodcastId))
                {

                    ListenerListPodcast listenerListPodcast = new();

                    ListenerList listenerList = _context.ListenerLists.First(ll => ll.Id == vm.ListenerListId);
                    Podcast podcast = _context.Podcasts.First(p => p.Id == vm.PodcastId);

                    listenerListPodcast.Podcast = podcast;
                    listenerListPodcast.ListenerList= listenerList;

                    _context.ListenerListPodcasts.Add(listenerListPodcast);

                    _context.SaveChanges();
                    vm.ViewMessage = $"Successfully added {podcast.Title} to the Listener List {listenerList.Name}";
                }
                else
                {
                    vm.ViewMessage = $"{vm.PodcastTitle} already included on selected Listener List";
                }

                vm.PopulateList(_context.ListenerLists);
                return View(vm);
            }
            else
            {
                return NotFound();
            }
        }



    }
}
