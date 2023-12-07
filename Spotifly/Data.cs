using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotifly
{
    internal class Data
    {
        public static List<Song> Songs { get; set; } = new();
        public static List<Artist> Artists { get; set; } = new();
        public static List<Playlist> Playlists { get; set; } = new();

        public static void AddData()
        {
            Artist a1 = new Artist();
            a1.Name = "Michael Jackson";
            a1.Birthday = new DateTime(1958, 8, 29);
            a1.User = "Henrik";
            a1.Country = "USA";
            Artists.Add(a1);

            Artist a2 = new()
            {
                Name = "Bob Marley",
                Country = "Jamaica",
                Birthday = new DateTime(1945, 2, 6),
            };
            Artists.Add(a2);


            //Console.WriteLine(a1);

            Song s1 = new Song()
            {
                Title = "Stay with me",
                Genre = "Pip Roeggae",
                Length = 225,
                ReleaseDate = new DateTime(1984, 12, 1),
                Artists = new List<Artist>() { a1, a2 },
                User = "Fans"
            };
            Song s2 = new Song()
            {
                Title = "Stay with me part 2",
                Genre = "Pip Roeggae",
                Length = 225,
                ReleaseDate = new DateTime(1985, 12, 1),
                Artists = new List<Artist>() { a1, a2 },
                User = "Fans"
            };
            Songs.AddRange(new List<Song>() { s1, s2 });
            Playlist p1 = new("Bedroom", new List<Song>() { s1, s2 });
            Playlists.Add(p1);
        }

        public static void AddDataFromConsole()
        {
            Console.WriteLine("Adding data through console...");

            while (true)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Add Artist");
                Console.WriteLine("2. Add Song");
                Console.WriteLine("3. Add Playlist");
                Console.WriteLine("4. Show Lists");
                Console.WriteLine("5. Finish Adding");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        AddArtist();
                        break;

                    case "2":
                        Console.Clear();
                        AddSong();
                        break;

                    case "3":
                        Console.Clear();
                        AddPlaylist();
                        break;

                    case "4":
                        Console.Clear();
                        ShowLists();
                        break;

                    case "5":
                        Console.WriteLine("Finished adding data through console.");
                        return;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
        private static void AddArtist()
        {
            Console.WriteLine("Adding new artist...");

            // Gather artist details from the user
            Console.Write("Enter artist name: ");
            string name = Console.ReadLine();

            Console.Write("Enter artist country: ");
            string country = Console.ReadLine();

            Console.Write("Enter artist birthday (yyyy-mm-dd): ");
            DateTime birthday;
            while (!DateTime.TryParse(Console.ReadLine(), out birthday))
            {
                Console.WriteLine("Invalid date format. Please enter the birthday in yyyy-mm-dd format.");
            }

            // Create and add the artist
            Artist newArtist = new Artist
            {
                Name = name,
                Country = country,
                Birthday = birthday
            };

            Artists.Add(newArtist);

            Console.WriteLine("Artist added successfully.");
        }
        private static void AddSong()
        {
            Console.WriteLine("Adding new song...");

            // Gather song details from the user
            Console.Write("Enter song title: ");
            string title = Console.ReadLine();

            Console.Write("Enter song genre: ");
            string genre = Console.ReadLine();

            Console.Write("Enter song length in seconds: ");
            int length;
            while (!int.TryParse(Console.ReadLine(), out length) || length < 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid non-negative integer for song length.");
            }

            // Choose an artist from the existing list
            Console.WriteLine("Select an artist for the song:");

            for (int i = 0; i < Artists.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Artists[i].Name}");
            }

            int selectedArtistIndex;
            while (!int.TryParse(Console.ReadLine(), out selectedArtistIndex) || selectedArtistIndex < 1 || selectedArtistIndex > Artists.Count)
            {
                Console.WriteLine("Invalid selection. Please enter a valid number.");
            }

            Artist selectedArtist = Artists[selectedArtistIndex - 1];

            // Create and add the song
            Song newSong = new Song
            {
                Title = title,
                Genre = genre,
                Length = length,
                Artists = new List<Artist> { selectedArtist }
            };

            Songs.Add(newSong);

            Console.WriteLine("Song added successfully.");
        }

        private static void AddPlaylist()
        {
            Console.WriteLine("Adding new playlist...");

            // Gather playlist details from the user
            Console.Write("Enter playlist name: ");
            string name = Console.ReadLine();

            // Display existing songs
            Console.WriteLine("Existing Songs:");
            for (int i = 0; i < Songs.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Songs[i].Title}");
            }

            // Choose songs from the existing list
            Console.WriteLine("Select songs for the playlist (enter numbers separated by commas, or enter 0 to finish):");

            List<Song> selectedSongs = new List<Song>();
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int selectedSongIndex))
                {
                    if (selectedSongIndex == 0)
                    {
                        break;
                    }

                    if (selectedSongIndex > 0 && selectedSongIndex <= Songs.Count)
                    {
                        selectedSongs.Add(Songs[selectedSongIndex - 1]);
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection. Please enter valid numbers separated by commas.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter valid numbers separated by commas.");
                }
            }

            // Create and add the playlist
            Playlist newPlaylist = new Playlist(name, selectedSongs);
            Playlists.Add(newPlaylist);

            Console.WriteLine("Playlist added successfully.");
        }

        private static void ShowLists()
        {
            Console.Clear(); // Clear the console screen

            Console.WriteLine("\nCurrent Lists:");

            Console.WriteLine("\nArtists:");
            for (int i = 0; i < Artists.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Name: {Artists[i].Name}, Country: {Artists[i].Country}, Birthday: {Artists[i].Birthday.ToShortDateString()}");
            }

            Console.WriteLine("\nSongs:");
            for (int i = 0; i < Songs.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Title: {Songs[i].Title}, Genre: {Songs[i].Genre}, Length: {Songs[i].Length} seconds");
            }

            Console.WriteLine("\nPlaylists:");
            for (int i = 0; i < Playlists.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Title: {Playlists[i].Title}, Song Count: {Playlists[i].Songs.Count}, Total Time: {Playlists[i].Time}");
            }

            Console.WriteLine("\nPress Enter to return to the main menu.");
            Console.ReadLine();
        }
    }

}
