using MusicApp.Common;

namespace MusicApp.Models
{
    public class Album : BaseEntity
    {
        public List<Song> Songs { get; set; } = new List<Song>();
        public string Artist { get; set; }
        public Album(string name)
        {
            Name = name;
            Songs = new List<Song>();
            
        }

    }
}
