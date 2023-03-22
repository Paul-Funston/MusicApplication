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

            Playlist playlistOne = new Playlist("Summer Hits");
            Playlist playlistTwo = new Playlist("Winter Blues");
            Playlist playlistThree = new Playlist("High Energy");

            if(!context.Playlists.Any())
            {
                context.Playlists.Add(playlistOne);
                context.Playlists.Add(playlistTwo);
                context.Playlists.Add(playlistThree);
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

            await context.SaveChangesAsync();

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

            await context.SaveChangesAsync();


        }
    }
}
