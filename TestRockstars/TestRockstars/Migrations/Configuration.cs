namespace TestRockstars.Migrations
{
    using System.Data.Entity.Migrations;
    using TestRockstars.DAL;
    using TestRockstars.Parser;
    using TestRockstars.Repositories;

    internal sealed class Configuration : DbMigrationsConfiguration<TestRockstars.DAL.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TestRockstars.DAL.DatabaseContext context)
        {
            JSONParser parse = new JSONParser();
            SongsRepository songRepository = new SongsRepository(context);
            ArtistsRepository artistRepository = new ArtistsRepository(context);
            artistRepository.ClearArtists();
            songRepository.ClearSongs();
            songRepository.AddSong(parse.GetSongs().ToArray());
            artistRepository.AddArtist(parse.GetArtists().ToArray());
        }
    }
}
