namespace MusicApplication.Models
{
    public class SongContributer
    {
        public int Id { get; set; }
        public virtual Artist Artist { get; set; }
        public int ArtistId { get; set; }
        public virtual Song Song { get; set; }
        public int SongId { get; set;}

        public SongContributer() { }

        public SongContributer(Song song, Artist artist)
        {
            Artist = artist;
            ArtistId = artist.Id;
            Song = song;
            SongId = song.Id;
        }

    }
}
