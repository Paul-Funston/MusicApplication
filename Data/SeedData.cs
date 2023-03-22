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
                await context.SaveChangesAsync();
                context.Songs.Add(songTwo);
                await context.SaveChangesAsync();
                context.Songs.Add(songThree);
                await context.SaveChangesAsync();
                context.Songs.Add(songFour);
                await context.SaveChangesAsync();
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

            SongContributer songContributerOne = new SongContributer(songOne, artistOne);
            SongContributer songContributerTwo = new SongContributer(songTwo, artistOne);
            SongContributer songContributerThree = new SongContributer(songThree, artistOne);
            SongContributer songContributerFour = new SongContributer(songFour, artistOne);
            SongContributer songContributerFive = new SongContributer(songFive, artistOne);
            SongContributer songContributerSix = new SongContributer(songSix, artistOne);
            SongContributer songContributerSeven = new SongContributer(songNineteen, artistOne);
            SongContributer songContributerEight = new SongContributer(songTwenty, artistOne);
            SongContributer songContributerNine = new SongContributer(songSeven, artistTwo);
            SongContributer songContributerTen = new SongContributer(songEight, artistTwo);
            SongContributer songContributerEleven = new SongContributer(songNine, artistTwo);
            SongContributer songContributerTwelve = new SongContributer(songTen, artistTwo);
            SongContributer songContributerThirteen = new SongContributer(songEleven, artistTwo);
            SongContributer songContributerFourteen = new SongContributer(songTwelve, artistTwo);
            SongContributer songContributerFifteen = new SongContributer(songThirteen, artistTwo);
            SongContributer songContributerSixteen = new SongContributer(songFourteen, artistTwo);
            SongContributer songContributerSeventeen = new SongContributer(songFifteen, artistTwo);
            SongContributer songContributerEighteen = new SongContributer(songSixteen, artistThree);
            SongContributer songContributerNineteen = new SongContributer(songSeventeen, artistThree);
            SongContributer songContributerTwenty = new SongContributer(songEighteen, artistThree);
            SongContributer songContributerTwentyOne = new SongContributer(songNineteen, artistThree);
            SongContributer songContributerTwentyTwo = new SongContributer(songTwenty, artistThree);

            if (!context.SongContributers.Any())
            {
                context.SongContributers.Add(songContributerOne);
                context.SongContributers.Add(songContributerTwo);
                context.SongContributers.Add(songContributerThree);
                context.SongContributers.Add(songContributerFour);
                context.SongContributers.Add(songContributerFive);
                context.SongContributers.Add(songContributerSix);
                context.SongContributers.Add(songContributerSeven);
                context.SongContributers.Add(songContributerEight);
                context.SongContributers.Add(songContributerNine);
                context.SongContributers.Add(songContributerTen);
                context.SongContributers.Add(songContributerEleven);
                context.SongContributers.Add(songContributerTwelve);
                context.SongContributers.Add(songContributerThirteen);
                context.SongContributers.Add(songContributerFourteen);
                context.SongContributers.Add(songContributerFifteen);
                context.SongContributers.Add(songContributerSixteen);
                context.SongContributers.Add(songContributerSeventeen);
                context.SongContributers.Add(songContributerEighteen);
                context.SongContributers.Add(songContributerNineteen);
                context.SongContributers.Add(songContributerTwenty);
                context.SongContributers.Add(songContributerTwentyOne);
                context.SongContributers.Add(songContributerTwentyTwo);
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
