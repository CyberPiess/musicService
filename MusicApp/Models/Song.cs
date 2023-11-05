using MusicApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Models
{
    public class Song : BaseEntity
    {
        public string Artist { get; set; }
        public string Album { get; set; }
        public string Genre { get; set; }
        public Song(string name)
        {
            Name = name;
        }

    }
}
