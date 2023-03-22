namespace MusicApplication.Models
{
    public class MediaContributer
    {
        public int Id { get; set; }
        public virtual Artist Artist { get; set; }
        public int ArtistId { get; set; }
        public virtual Media Media { get; set; }
        public int MediaId { get; set;}

        
        public MediaContributer() { }

        public MediaContributer(Media media, Artist artist)
        {
            Artist = artist;
            ArtistId = artist.Id;
            Media = media;
            MediaId = media.Id;
        }

    }
}
