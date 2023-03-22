namespace MusicApplication.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual HashSet<MediaContributer> SongContributers { get; set; } = new();

        public Artist() { }

        public Artist(string name) { Name = name; }
    }
}
