namespace MusicApplication.Models
{
    public class Playlist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual HashSet<PlaylistSong> PlaylistSongs { get; set; } = new();

        public Playlist() { }
        public Playlist(string name) { Name = name; }
    }
}
