namespace MusicApplication.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual HashSet<Song> Songs { get; set; } = new HashSet<Song>();

        public Album() { }

        public Album(string title) { Title = title; }
    }
}
