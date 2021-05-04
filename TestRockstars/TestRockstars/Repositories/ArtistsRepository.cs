
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using TestRockstars.DAL;
using TestRockstars.Models;

namespace TestRockstars.Repositories
{
    public class ArtistsRepository
    {
        DatabaseContext dbContext;
        public ArtistsRepository(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AddArtist(params Artist[] artists)
        {
            foreach (Artist artist in artists)
            {
                dbContext.Artists.Add(artist);
            }
            dbContext.SaveChanges();
        }

        public void ClearArtists()
        {
            dbContext.Artists.RemoveRange(dbContext.Artists);
        }

        //Saves the database
        public Task SaveChangesAsync()
        {
            return dbContext.SaveChangesAsync();
        }

        public IQueryable<Artist> GetArtists()
        {
            return dbContext.Artists;
        }

        public Task<Artist> FindArtistAsync(int id)
        {
            return dbContext.Artists.FindAsync(id);
        }

        public void ChangeState(Artist artist)
        {
            dbContext.Entry(artist).State = EntityState.Modified;
        }

        public void RemoveArtist(Artist artist)
        {
            dbContext.Artists.Remove(artist);
        }

        internal void Dispose()
        {
            dbContext.Dispose();
        }
    }
}