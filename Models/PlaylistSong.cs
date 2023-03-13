namespace MusicApplication.Models
{
    public class PlaylistSong
    {
        public int Id { get; set; }
        public virtual Song Song { get; set; }
        public int SongId { get; set; }
        public virtual Playlist Playlist { get; set; }
        public int PlaylistId { get; set; }
        public DateTime TimeAdded { get; set; }

        public PlaylistSong() { }

        public PlaylistSong(Playlist playlist, Song song)
        {
            Song = song;
            SongId = song.Id;
            Playlist = playlist;
            PlaylistId = playlist.Id;
            TimeAdded = DateTime.Now;
        }
    }
}
