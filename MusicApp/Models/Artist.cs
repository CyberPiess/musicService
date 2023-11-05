using MusicApp.Common;

namespace MusicApp.Models
{
    public class Artist : BaseEntity
    {
         
        public List<Album> Albums {  get; set; } 
       
        public Artist(string name) 
        {
            Name = name; 
            Albums = new List<Album>();
        }

    }
}
