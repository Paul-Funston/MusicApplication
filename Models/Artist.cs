namespace MusicApplication.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual HashSet<MediaContributer> MediaContributers { get; set; } = new();
        public virtual HashSet<PodcastContributer> PodcastContributers { get; set; } = new();

        public Artist() { }

        public Artist(string name) { Name = name; }
    }
}
