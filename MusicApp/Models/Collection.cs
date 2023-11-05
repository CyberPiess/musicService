using MusicApp.Common;

namespace MusicApp.Models
{
    public class Collection : BaseEntity
    {
        public List<Genre> Genres { get; set; }
        public Collection(string name)
        {
            Name = name;
            Genres = new List<Genre>();
        }

    }
}
