using System.ComponentModel.DataAnnotations;

namespace MusicApplication.Models
{
    public abstract class Media
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [Display(Name = "Duration")]
        
        public int DurationSeconds { get; set; }

        public string ReadableDuration()
        {
            TimeSpan ts = TimeSpan.FromSeconds(DurationSeconds);

            return ts.ToString("c");
        }
        public int MediaCollectionId { get; set; }

        [Display(Name = "#")]
        public int CollectionOrderNumber { get; set; }

        public virtual HashSet<MediaContributer> MediaContributers { get; set; } = new();
        public virtual string GetAllArtists()
        {
            List<string> artists = MediaContributers.Select(sc => sc.Artist.Name).ToList();

            return string.Join(", ", artists);
        }

        public Media() { }

        public Media(string title, int durationSeconds, int mediaCollectionId, int orderNumber)
        {

            Title = title;
            DurationSeconds = durationSeconds;
            MediaCollectionId = mediaCollectionId;
            CollectionOrderNumber = orderNumber;
        }
    }
    public class Song : Media
    {
        
        public virtual Album Album { get; set;}

        
        
        
        
        
        public virtual HashSet<PlaylistSong> PlaylistSongs { get; set; } = new();

        

        public Song() : base() { }

        public Song(string title, int durationSeconds, Album album, int orderNumber) : base(title, durationSeconds, album.Id, orderNumber)
        {
            Album = album;
            CollectionOrderNumber = orderNumber;
        }
    }

    public class Episode : Media
    {
        public virtual Podcast Podcast { get; set; }

        
        public Episode() : base() { }

        public Episode(string title, int durationSeconds, Podcast podcast, int orderNumber) : base(title, durationSeconds, podcast.Id, orderNumber)
        {
            Podcast = podcast;
            CollectionOrderNumber = orderNumber;
        }
    }
}
