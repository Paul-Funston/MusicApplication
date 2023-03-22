namespace MusicApplication.Models
{
    public abstract class MediaCollection
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public MediaCollection() { }

        public MediaCollection(string title) 
        {
            Title = title;
        }
    }
    public class Album : MediaCollection 
    {
        
        public virtual HashSet<Song> Songs { get; set; } = new HashSet<Song>();

        public Album() { }

        public Album(string title) : base(title) {  }
    }

    public class Podcast : MediaCollection
    {
        public virtual HashSet<Episode> Episodes { get; set; } = new HashSet<Episode> ();

        public Podcast() : base() { }
        public Podcast(string title) : base(title) { }

    }
}
