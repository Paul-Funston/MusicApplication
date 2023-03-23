namespace MusicApplication.Models
{
    public class ListenerList
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public HashSet<ListenerListPodcast> ListenerListPodcasts = new HashSet<ListenerListPodcast> ();
        public ListenerList() { }

        public ListenerList( string name)
        {
            Name = name;
        }
    }
}
