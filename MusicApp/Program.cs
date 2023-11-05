using MusicApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

Repository repository = new Repository();

bool end = false;
string menuCont = "-----------------------------------------\nМеню: \n\n";
menuCont += "Добавить исполнителя \n";
menuCont += "Добавить альбом \n";
menuCont += "Добавить трек \n";
menuCont += "Добавить коллекцию \n";
menuCont += "Поиск ипсолнителей \n";
menuCont += "Поиск альбомов \n";
menuCont += "Поиск песни \n";
menuCont += "Поиск коллекции \n";
menuCont += "Выйти \n\n";
menuCont += "Выберите пункт: ";

while (end == false)
{
    Console.Write(menuCont);
    var menuItem = Console.ReadLine();
    
    switch (menuItem)
    {
        case "Добавить исполнителя":
            Console.Write("\nВведите имя артиста: ");
            var artistName = Console.ReadLine();
            var newArtist = new Artist(artistName);
            repository.Add(newArtist);
            Console.Write("Артист добавлен\n\n");
            break;

        case "Добавить альбом":
            Console.Write("\nВведите имя исполнителя: ");
            artistName = Console.ReadLine();
            Console.Write("Введите название альбома: ");
            var albumName = Console.ReadLine();
            var newAlbum = new Album(albumName);
            repository.Albums.Add(newAlbum);
            var foundArtist = repository.SearchArtist(artistName);
            newAlbum.Artist = artistName;
            foundArtist.Albums.Add(newAlbum);
            Console.Write("Альбом успешно добавлен\n\n");
            break;

        case "Добавить трек":
            Console.Write("\nВведите имя исполнителя: ");
            artistName = Console.ReadLine();
            Console.Write("Введите название альбома: ");
            albumName = Console.ReadLine();
            Console.Write("Введите название трека: ");
            var songName = Console.ReadLine();
            Console.Write("Введите жанр: ");
            var genreName = Console.ReadLine();
            var genreExists = repository.SearchGenre(genreName);
            var newSong = new Song(songName);
            repository.Songs.Add(newSong);
            if (genreExists != null)
            {
                genreExists.Songs.Add(newSong);
            }
            else
            {
                genreExists = new Genre(genreName);
                repository.Genres.Add(genreExists);
                genreExists.Songs.Add(newSong);
            }
            newSong.Artist = artistName;
            newSong.Album = albumName;
            newSong.Genre = genreName;
            var foundAlbum = repository.SearchAlbum(artistName, albumName);
            foundAlbum.Songs.Add(newSong);
            Console.WriteLine("Трек успешно добавлен\n");
            break;

        case "Добавить коллекцию":
            Console.Write("\nВведите название коллекции: ");
            var collectionName = Console.ReadLine();
            var newCollection = new Collection(collectionName);
            repository.Collections.Add(newCollection);
            var nextGenre = true;
            while (nextGenre)
            {
                Console.Write("Какой жанр хотите добавить: ");
                genreName = Console.ReadLine();
                var foundGenre = repository.SearchGenre(genreName);
                if (foundGenre == null)
                {
                    Console.Write("Такого жанра нет :(");
                }
                else newCollection.Genres.Add(foundGenre);
                Console.Write("Хотите добавить еще один жанр (да/нет): ");
                var moreGenre = Console.ReadLine();
                nextGenre = moreGenre == "Да" ? nextGenre : false;
            }
            Console.WriteLine("Коллекция добавлена\n");
            break;

        case "Поиск исполнителей":
            Console.Write("Введите имя артиста: ");
            var wantedArtist = Console.ReadLine();
            var foundArtists = repository.SearchObjects(wantedArtist, repository.Artists);
            if (foundArtists.Count() != 0)
            {
                Console.Write("Найденные артисты: ");

                foreach (Artist artist in foundArtists)
                {
                     
                    Console.WriteLine("\n" + artist.Name);
                }
                Console.Write("\n");
            }
            else 
            {
                Console.WriteLine("\nИсполнитель не найден");
               
            }
            break;

        case "Поиск альбомов":
            Console.Write("Введите албьом: ");
            var wantedAlbums = Console.ReadLine();
            var foundAlbums = repository.SearchObjects(wantedAlbums, repository.Albums);
            if (foundAlbums.Count() != 0)
            {
                Console.Write("Все альбомы, завнаие которых содержит заданное название: \n");
                foreach (Album album in foundAlbums)
                {
                    Console.Write("Альбом: " + album.Name);
                    Console.Write("\nИсполнитель: " + album.Artist + "\n");
                }
            }
            else
            {
                Console.WriteLine("Альбомы не найдены");
            }
            
            break;
        case "Поиск коллекции":
            Console.Write("Введите имя коллекции: ");
            var wantedCollection = Console.ReadLine();
            var foundCollection = repository.SearchObjects(wantedCollection, repository.Collections);
            if (foundCollection.Count() != 0)
            {
                Console.WriteLine("\nНайденные коллекции: ");
                foreach (Collection collection in foundCollection)
                {
                    Console.Write("Коллекция: " + collection.Name + "\n\nЖанры в коллекции: \n");
                    foreach (Genre genre in collection.Genres)
                    {
                        Console.Write(genre.Name + "\n");
                    }
                }
            }
            else
            {
                Console.WriteLine("Коллекции не найдены");
            }
           
            break;

        case "Поиск песни":
            Console.Write("Введите название песни: ");
            var searchSong = Console.ReadLine();
            var subMenu = "\nПоиск по наименованию\n";
            subMenu += "Поиск по жанру\n";
            subMenu += "Поиск по альбому\n";
            subMenu += "Поиск по исполнителю\n";
            subMenu += "\nВыберите пункт: ";
            Console.Write(subMenu);
            var foundSong = repository.SearchObjects(searchSong, repository.Songs);
            var subMenuItem = Console.ReadLine();
            switch(subMenuItem)
            {
                case "Поиск по наименованию":
                    break;

                case "Поиск по жанру":
                    Console.Write("Введите жанр: ");
                    var searchGenre = Console.ReadLine();
                    var foundGenre = repository.SearchGenre(searchGenre);
                    foundSong = repository.SearchObjects(searchSong, foundGenre.Songs);
                    break;
                case "Поиск по исполнителю":
                    Console.Write("Введите исполнителя: ");
                    var searchArtist = Console.ReadLine();
                    foundArtist = repository.SearchArtist(searchArtist);
                    foreach(Album album in foundArtist.Albums)
                    {
                        foundSong = repository.SearchObjects(searchSong, album.Songs);
                    }                  
                    break;
                case "Поиск по альбому":
                    Console.Write("Введите альбом: ");
                    var searchAlbum = Console.ReadLine();
                    foundAlbum = repository.SearchOnlyAlbum(searchAlbum);
                    foundSong = repository.SearchObjects(searchSong, foundAlbum.Songs);
                    break;
            }
            
            if (foundSong.Count() != 0)
            {
                Console.Write("\nНайденные пенси");
                    foreach (Song song in foundSong)
                {
                    Console.Write("\nНазвание песни: " + song.Name);
                    Console.Write("\nЖанр: " + song.Genre);
                    Console.Write("\nАльбом: " + song.Album);
                    Console.Write("\nИсполнитель: " + song.Artist + "\n");
                }
            }
            else
            {
                Console.Write("Песни не найдены\n");
            }

            break;

        case "Выйти":
            end = true;
            break;
        default:
            Console.WriteLine("Error");
            break;
    }
}
