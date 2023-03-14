namespace MusicApplication.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int DurationSeconds { get; set; }
        public virtual Album Album { get; set;}
        public int AlbumId { get; set; }
        public virtual HashSet<SongContributer> SongContributers { get; set; } = new();
        public virtual HashSet<PlaylistSong> PlaylistSongs { get; set; } = new();

        public string GetAllArtists()
        {
           List<string> artists = SongContributers.Select(sc => sc.Artist.Name).ToList();

            return string.Join(", ", artists);
        }

        public Song() { }

        public Song(string title, int durationSeconds, Album album)
        {
            Title = title;
            DurationSeconds = durationSeconds;
            Album = album;
            AlbumId = album.Id;
        }
    }
}
