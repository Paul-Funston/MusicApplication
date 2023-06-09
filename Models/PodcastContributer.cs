﻿namespace MusicApplication.Models
{
    public class PodcastContributer
    {
        public int Id { get; set; }
        public virtual Artist Artist { get; set; }
        public int ArtistId { get; set; }
        public virtual Podcast Podcast { get; set; }
        public int PodcastId { get; set; }


        public PodcastContributer() { }

        public PodcastContributer(Podcast podcast, Artist artist)
        {
            Artist = artist;
            ArtistId = artist.Id;
            Podcast = podcast;
            PodcastId = podcast.Id;
        }
    }
}
