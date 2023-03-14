using Microsoft.AspNetCore.Mvc.Rendering;

namespace MusicApplication.Models.ViewModel
{
    public class AddToPlaylistVM
    {
        public HashSet<SelectListItem> Playlists { get; set; } = new HashSet<SelectListItem>();

        public int? SongId { get; set; }
        public string? SongTitle { get; set; }
        
        public int? PlaylistId { get; set; }

        public string? ViewMessage { get; set; }
        public void PopulateList(IEnumerable<Playlist> playlists) 
        {
            foreach(Playlist p in playlists)
            {
                Playlists.Add(new SelectListItem($"{p.Name}", p.Id.ToString()));
            }
        }

        public AddToPlaylistVM() { }
        public AddToPlaylistVM(IEnumerable<Playlist> playlists, int songId, string songTitle)
        {
            PopulateList(playlists);
            SongId = songId;
            SongTitle = songTitle;
        }
    }
}
