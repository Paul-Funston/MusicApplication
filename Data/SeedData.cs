using Microsoft.EntityFrameworkCore;
using MusicApplication.Models;
using System.Security.Policy;
using System.Threading;

namespace MusicApplication.Data
{
    public static class SeedData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            MusicApplicationContext context = new MusicApplicationContext(serviceProvider.GetRequiredService<DbContextOptions<MusicApplicationContext>>());

            context.Database.EnsureDeleted();
            context.Database.Migrate();
            try
            {

                Artist artistOne = new Artist("Riell");
                Artist artistTwo = new Artist("The Tech Thieves");
                Artist artistThree = new Artist("Jim Yosef");

                if(!context.Artists.Any())
                {
                    context.Artists.Add(artistOne);
                    context.Artists.Add(artistTwo);
                    context.Artists.Add(artistThree);
                }

                Album albumOne = new Album("Better Off");
                Album albumTwo = new Album("Paradise");
                Album albumThree = new Album("The Purple EP");
                Album albumFour = new Album("The Blue EP");
                Album albumFive = new Album("End of Time");
                Album albumSix = new Album("Animal");

                if(!context.Albums.Any())
                {
                    context.Albums.Add(albumOne);
                    context.Albums.Add(albumTwo);
                    context.Albums.Add(albumThree);
                    context.Albums.Add(albumFour);
                    context.Albums.Add(albumFive);
                    context.Albums.Add(albumSix);
                }

                Podcast podcastOne = new Podcast("Planet Money");
                Podcast podcastTwo = new Podcast("Waypoint Radio");
                Podcast podcastThree = new Podcast("99% Invisible");
                Podcast podcastFour = new Podcast("A Podcast of Unnecessary Detail");

                if (!context.Podcasts.Any())
                {
                    context.Podcasts.Add(podcastOne);
                    context.Podcasts.Add(podcastTwo);
                    context.Podcasts.Add(podcastThree);
                    context.Podcasts.Add(podcastFour);
                }


                Playlist playlistOne = new Playlist("Summer Hits");
                Playlist playlistTwo = new Playlist("Winter Blues");
                Playlist playlistThree = new Playlist("High Energy");

                if(!context.Playlists.Any())
                {
                    context.Playlists.Add(playlistOne);
                    context.Playlists.Add(playlistTwo);
                    context.Playlists.Add(playlistThree);
                }

                ListenerList listenerListOne = new ListenerList("Comedy");
                ListenerList listenerListTwo = new ListenerList("Science");

                if (!context.ListenerLists.Any())
                {
                    context.ListenerLists.Add(listenerListOne);
                    context.ListenerLists.Add(listenerListTwo);
                }

                await context.SaveChangesAsync();

                Song songOne = new Song("Better Off", 191, albumOne , 1);
                Song songTwo = new Song("Selfish", 150, albumOne, 2);
                Song songThree = new Song("All I Know", 188, albumOne, 3);
                Song songFour = new Song("Paradise", 198, albumTwo, 1);
                Song songFive = new Song("Somewhere New", 201, albumTwo, 2);
                Song songSix = new Song("First", 191, albumTwo, 3);
                Song songSeven = new Song("Dangerous", 158, albumThree, 1);
                Song songEight = new Song("Something More", 156, albumThree, 2);
                Song songNine = new Song("Anxiety", 175, albumThree, 3);
                Song songTen = new Song("Keep You", 154, albumThree, 4);
                Song songEleven = new Song("Bang!", 141, albumFour, 1);
                Song songTwelve = new Song("Lighthouse", 142, albumFour, 2);
                Song songThirteen = new Song("Fall", 172, albumFour, 3);
                Song songFourteen = new Song("Just Like Me", 163, albumFour, 4);
                Song songFifteen = new Song("Repeat", 202, albumFour, 5);
                Song songSixteen = new Song("Carousel", 134, albumFive, 1);
                Song songSeventeen = new Song("Ghost",187, albumFive, 2);
                Song songEighteen = new Song("Time", 171, albumFive, 3);
                Song songNineteen = new Song("Hate You", 200, albumSix, 1);
                Song songTwenty = new Song("Animal", 172, albumSix, 2);

                if (!context.Songs.Any())
                {
                    context.Songs.Add(songOne);
                    context.Songs.Add(songTwo);
                    context.Songs.Add(songThree);
                    context.Songs.Add(songFour);
                    context.Songs.Add(songFive);
                    context.Songs.Add(songSix);
                    context.Songs.Add(songSeven);
                    context.Songs.Add(songEight);
                    context.Songs.Add(songNine);
                    context.Songs.Add(songTen);
                    context.Songs.Add(songEleven);
                    context.Songs.Add(songTwelve);
                    context.Songs.Add(songThirteen);
                    context.Songs.Add(songFourteen);
                    context.Songs.Add(songFifteen);
                    context.Songs.Add(songSixteen);
                    context.Songs.Add(songSeventeen);
                    context.Songs.Add(songEighteen);
                    context.Songs.Add(songNineteen);
                    context.Songs.Add(songTwenty);

                }

                Episode episodeOne = new Episode("The value of good teeth", 1344, podcastOne, 1620, new DateTime(2023, 3, 8));
                Episode episodeTwo = new Episode("Dude, where's my streaming TV show", 1598, podcastOne, 1621, new DateTime(2023, 3, 10));
                Episode episodeThree = new Episode("How Silicon Valley Bank failed", 1278, podcastOne, 1622, new DateTime(2023, 3, 15));
                Episode episodeFour = new Episode("Throw King Rob Into the River", 6240, podcastTwo, 547, new DateTime(2023,3, 7));
                Episode episodeFive = new Episode("The Last of the Last of Us", 5820, podcastTwo, 549, new DateTime(2023, 3,14));
                Episode episodeSix = new Episode("My Turn - The Lighthouse (2019)", 6666, podcastTwo, 550, new DateTime(2023,3,15));
                Episode episodeSeven = new Episode("Orange Alternative", 1920, podcastThree,526, new DateTime(2023, 2, 21));
                Episode episodeEight = new Episode("RoboUmp", 1680, podcastThree, 527, new DateTime(2023,2,28));
                Episode episodeNine = new Episode("The Wilderness Tool", 2640, podcastThree, 529, new DateTime(2023, 3, 21));
                Episode episodeTen = new Episode("Flush and Forget", 2880, podcastFour, 1, new DateTime(2022, 3, 29));
                Episode episodeEleven = new Episode("Primed and Ready", 2611, podcastFour, 2, new DateTime(2022, 4, 5));
                Episode episodeTwelve = new Episode("Go Forth and Multiply", 3000, podcastFour, 3, new DateTime(2022, 4, 12));

                if (!context.Episodes.Any())
                {
                    context.Episodes.Add(episodeOne);
                    context.Episodes.Add(episodeTwo);
                    context.Episodes.Add(episodeThree);
                    context.Episodes.Add(episodeFour);
                    context.Episodes.Add(episodeFive);
                    context.Episodes.Add(episodeSix);
                    context.Episodes.Add(episodeSeven);
                    context.Episodes.Add(episodeEight);
                    context.Episodes.Add(episodeNine);
                    context.Episodes.Add(episodeTen);
                    context.Episodes.Add(episodeEleven);
                    context.Episodes.Add(episodeTwelve);
                    
                }



                await context.SaveChangesAsync();

                PodcastContributer PodcastContributerOne = new PodcastContributer(podcastOne, artistOne);
                PodcastContributer PodcastContributerTwo = new PodcastContributer(podcastTwo, artistTwo);
                PodcastContributer PodcastContributerThree = new PodcastContributer(podcastThree, artistThree);
                PodcastContributer PodcastContributerFour = new PodcastContributer(podcastFour, artistOne);
                PodcastContributer PodcastContributerFive = new PodcastContributer(podcastFour, artistThree);

                if(!context.PodcastContributers.Any())
                {
                    context.PodcastContributers.Add(PodcastContributerOne);
                    context.PodcastContributers.Add(PodcastContributerTwo);
                    context.PodcastContributers.Add(PodcastContributerThree);
                    context.PodcastContributers.Add(PodcastContributerFour);
                    context.PodcastContributers.Add(PodcastContributerFive);
                }

                MediaContributer songContributerOne = new MediaContributer(songOne, artistOne);
                MediaContributer songContributerTwo = new MediaContributer(songTwo, artistOne);
                MediaContributer songContributerThree = new MediaContributer(songThree, artistOne);
                MediaContributer songContributerFour = new MediaContributer(songFour, artistOne);
                MediaContributer songContributerFive = new MediaContributer(songFive, artistOne);
                MediaContributer songContributerSix = new MediaContributer(songSix, artistOne);
                MediaContributer songContributerSeven = new MediaContributer(songNineteen, artistOne);
                MediaContributer songContributerEight = new MediaContributer(songTwenty, artistOne);
                MediaContributer songContributerNine = new MediaContributer(songSeven, artistTwo);
                MediaContributer songContributerTen = new MediaContributer(songEight, artistTwo);
                MediaContributer songContributerEleven = new MediaContributer(songNine, artistTwo);
                MediaContributer songContributerTwelve = new MediaContributer(songTen, artistTwo);
                MediaContributer songContributerThirteen = new MediaContributer(songEleven, artistTwo);
                MediaContributer songContributerFourteen = new MediaContributer(songTwelve, artistTwo);
                MediaContributer songContributerFifteen = new MediaContributer(songThirteen, artistTwo);
                MediaContributer songContributerSixteen = new MediaContributer(songFourteen, artistTwo);
                MediaContributer songContributerSeventeen = new MediaContributer(songFifteen, artistTwo);
                MediaContributer songContributerEighteen = new MediaContributer(songSixteen, artistThree);
                MediaContributer songContributerNineteen = new MediaContributer(songSeventeen, artistThree);
                MediaContributer songContributerTwenty = new MediaContributer(songEighteen, artistThree);
                MediaContributer songContributerTwentyOne = new MediaContributer(songNineteen, artistThree);
                MediaContributer songContributerTwentyTwo = new MediaContributer(songTwenty, artistThree);
                MediaContributer episodeContributerOne = new MediaContributer(episodeTwo, artistTwo);
                MediaContributer episodeContributerTwo = new MediaContributer(episodeNine, artistTwo);
                MediaContributer episodeContributerThree = new MediaContributer(episodeFour, artistThree);
                MediaContributer episodeContributerFour = new MediaContributer(episodeFive, artistOne);
                
                if (!context.MediaContributers.Any())
                {
                    context.MediaContributers.Add(songContributerOne);
                    context.MediaContributers.Add(songContributerTwo);
                    context.MediaContributers.Add(songContributerThree);
                    context.MediaContributers.Add(songContributerFour);
                    context.MediaContributers.Add(songContributerFive);
                    context.MediaContributers.Add(songContributerSix);
                    context.MediaContributers.Add(songContributerSeven);
                    context.MediaContributers.Add(songContributerEight);
                    context.MediaContributers.Add(songContributerNine);
                    context.MediaContributers.Add(songContributerTen);
                    context.MediaContributers.Add(songContributerEleven);
                    context.MediaContributers.Add(songContributerTwelve);
                    context.MediaContributers.Add(songContributerThirteen);
                    context.MediaContributers.Add(songContributerFourteen);
                    context.MediaContributers.Add(songContributerFifteen);
                    context.MediaContributers.Add(songContributerSixteen);
                    context.MediaContributers.Add(songContributerSeventeen);
                    context.MediaContributers.Add(songContributerEighteen);
                    context.MediaContributers.Add(songContributerNineteen);
                    context.MediaContributers.Add(songContributerTwenty);
                    context.MediaContributers.Add(songContributerTwentyOne);
                    context.MediaContributers.Add(songContributerTwentyTwo);
                    context.MediaContributers.Add(episodeContributerOne);
                    context.MediaContributers.Add(episodeContributerTwo);
                    context.MediaContributers.Add(episodeContributerThree);
                    context.MediaContributers.Add(episodeContributerFour);
                }

                // Validate all songs have an artist
                if (!AreSongsValid(context))
                {
                    throw new Exception("All songs must have at least one artist");
                }

                PlaylistSong playlistSongOne = new PlaylistSong(playlistOne, songTwenty);
                PlaylistSong playlistSongTwo = new PlaylistSong(playlistOne, songFour);
                PlaylistSong playlistSongThree = new PlaylistSong(playlistOne, songSeventeen);
                PlaylistSong playlistSongFour = new PlaylistSong(playlistTwo, songNineteen);
                PlaylistSong playlistSongFive = new PlaylistSong(playlistTwo, songOne);
                PlaylistSong playlistSongSix = new PlaylistSong(playlistTwo, songNine);
                PlaylistSong playlistSongSeven = new PlaylistSong(playlistThree, songSix);
                PlaylistSong playlistSongEight = new PlaylistSong(playlistThree, songSeven);
                PlaylistSong playlistSongNine = new PlaylistSong(playlistThree, songEleven);

                if(!context.PlaylistSongs.Any())
                {
                    context.PlaylistSongs.Add(playlistSongOne);
                    context.PlaylistSongs.Add(playlistSongTwo);
                    context.PlaylistSongs.Add(playlistSongThree);
                    context.PlaylistSongs.Add(playlistSongFour);
                    context.PlaylistSongs.Add(playlistSongFive);
                    context.PlaylistSongs.Add(playlistSongSix);
                    context.PlaylistSongs.Add(playlistSongSeven);
                    context.PlaylistSongs.Add(playlistSongEight);
                    context.PlaylistSongs.Add(playlistSongNine);
                }

                ListenerListPodcast listenerListPodcastOne = new ListenerListPodcast(listenerListOne,podcastTwo);
                ListenerListPodcast listenerListPodcastTwo = new ListenerListPodcast(listenerListOne, podcastFour);
                ListenerListPodcast listenerListPodcastThree = new ListenerListPodcast(listenerListTwo, podcastThree);
                ListenerListPodcast listenerListPodcastFour = new ListenerListPodcast(listenerListTwo,podcastOne);
                ListenerListPodcast listenerListPodcastFive = new ListenerListPodcast(listenerListTwo, podcastFour);

                if (!context.ListenerListPodcasts.Any())
                {
                    context.ListenerListPodcasts.Add(listenerListPodcastOne);
                    context.ListenerListPodcasts.Add(listenerListPodcastTwo);
                    context.ListenerListPodcasts.Add(listenerListPodcastThree);
                    context.ListenerListPodcasts.Add(listenerListPodcastFour);
                    context.ListenerListPodcasts.Add(listenerListPodcastFive);
                }

                await context.SaveChangesAsync();
                
            } catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
            

        }

        private static bool AreSongsValid(MusicApplicationContext context)
        {
            bool result = true;
            foreach(Song s in context.Songs.Include(s => s.MediaContributers))
            {
                if(s.MediaContributers.Count() == 0)
                {
                    result = false;
                    break;
                }
            }
            return result;
        }
    }

}
