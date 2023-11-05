
using MusicApp.Common;
using System.Collections;

namespace MusicApp.Models
{
    public class Repository
    {
        public List<Song> Songs { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Album> Albums { get; set; }
        public List<Collection> Collections { get; set; }
        public List<Artist> Artists { get; set; }

        public Repository()
        {
            Artists = new List<Artist>();
            Albums = new List<Album>();
            Collections = new List<Collection>();
            Songs = new List<Song>();
            Genres = new List<Genre>();
        }


        public void Add(Artist artist)
        {
            Artists.Add(artist);
        }
        public void Add(Album album)
        {
            Albums.Add(album);
        }
        public void Add(Collection collection)
        {
            Collections.Add(collection);
        }
        public void Add(Song song)
        {
            Songs.Add(song);
        }
        public void Add(Genre genre)
        {
            Genres.Add(genre);
        }

        public Artist SearchArtist(string artistName)
        {
            var foundArtist = Search(artistName, Artists);
            return foundArtist; 
        }

        public Album SearchAlbum(string artistName, string albumName)
        {
            var foundArtist = SearchArtist(artistName);
            var foundAlbum = Search(albumName, foundArtist.Albums);
            return foundAlbum;
        }

        public Album SearchOnlyAlbum(string albumName)
        {
            var foundAlbum = Search(albumName, Albums);
            return foundAlbum;
        }

        public Genre SearchGenre(string genreName)
        {

            var foundGenre = Search(genreName, Genres);
            return foundGenre;
        }

        private static T? Search<T>(string searchString, List<T> searchList) where T : BaseEntity
        {

            var foundItem = searchList.FirstOrDefault(x => x.Name.Contains(searchString));

            return foundItem;
        }
        public IEnumerable<T?> SearchObjects<T>(string searchString, List<T> searchList) where T : BaseEntity
        {

            var foundItem = searchList.Where(x => x.Name.Contains(searchString));

            return foundItem;
        }

    }

}
