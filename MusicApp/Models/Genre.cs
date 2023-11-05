using MusicApp.Common;

namespace MusicApp.Models
{
    public class Genre : BaseEntity
    {
        public List<Song> Songs { get; set; }
        public Genre(string name)
        {
            Name = name;
            Songs = new List<Song>();
        }

    }
}
