namespace MusicApplication.Models
{
    public class ListenerListPodcast
    {
        public int Id { get; set; }
        public ListenerList ListenerList { get; set; }
        public int ListenerListId { get; set; }

        public Podcast Podcast { get; set; }
        public int PodcastId { get; set; }

        public ListenerListPodcast() { }

        public ListenerListPodcast(ListenerList listenerList, Podcast podcast)
        {
            ListenerList = listenerList;
            ListenerListId = listenerList.Id;

            Podcast = podcast;
            PodcastId = podcast.Id;
        }
    }
}
