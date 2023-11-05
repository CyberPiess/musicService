

namespace MusicApp.Models
{
    public class Menu
    {
        public void startMenu()
        {
            bool end = false;
            string menuCont = "Выберите пункт меню: \n";
            menuCont += "0 - Добавить исполнителя \n";
            menuCont += "1 - Добавить альбом \n";
            menuCont += "2 - Добавить песню \n";
            menuCont += "3 - Добавить коллекцию \n";
            menuCont += "4 - Выйти";

            while (end == false)
            {
                Console.WriteLine(menuCont);
                var temp = Console.ReadLine();
                switch (temp) 
                {
                    case "Добавить исполнителя":
                        var artist = Console.ReadLine();
                        AddArtist(artist);
                        break;
                    case "Добавить альбом":
                        AddAlbum();
                        break;
                    case "Добавить песню":
                        AddSong();
                        break;
                    case "Добавить коллекцию":
                        AddCollection();
                        break;
                    case "Выйти":
                        end = true;
                        break;
                    default:
                        Console.WriteLine("Error");
                        break;
                }
            }
        }

        private void AddArtist(string? artist)
        {
            

        }

        private void AddSong()
        {
            
        }
        private void AddAlbum()
        {
            
        }
        private void AddCollection()
        {
            
        }
     
    }
}
