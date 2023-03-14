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

        [HttpGet]
        public IActionResult AddToPlaylist(int id)
        {
            Song? song = _context.Songs.FirstOrDefault(s => s.Id == id);
            if(song == null) { return NotFound(); }
            AddToPlaylistVM vm = new AddToPlaylistVM(_context.Playlists, id, song.Title);
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> AddToPlaylist([Bind("SongId,PlaylistId,SongTitle")]AddToPlaylistVM vm)
        {
            if(vm.PlaylistId != null && vm.SongId != null)
            {
                if(!_context.PlaylistSongs.Any(ps => ps.PlaylistId == vm.PlaylistId && ps.SongId == vm.SongId))
                {

                    PlaylistSong playlistSong = new();

                    Playlist playlist = _context.Playlists.First(p => p.Id == vm.PlaylistId);
                    Song song = _context.Songs.First(s => s.Id == vm.SongId);

                    playlistSong.Song = song;
                    playlistSong.Playlist = playlist;

                    _context.PlaylistSongs.Add(playlistSong);

                    _context.SaveChanges();
                    vm.ViewMessage = $"Successfully added {song.Title} to the playlist {playlist.Name}";
                } else
                {
                    vm.ViewMessage = $"{vm.SongTitle} already included on selected playlist";
                }

                vm.PopulateList(_context.Playlists);
                return View(vm);
            } else
            {
                throw new Exception();
            }
        }



        

    }
}
