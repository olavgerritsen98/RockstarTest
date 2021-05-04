using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TestRockstars.DAL;
using TestRockstars.Models;

namespace TestRockstars.Repositories
{
    public class SongsRepository
    {
        private DatabaseContext dbContext;

        public  SongsRepository(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void AddSong(params Song[] songs)
        {
            foreach (Song song in songs)
            {
                dbContext.Songs.Add(song);
            }
            dbContext.SaveChanges();
        }

        public void ClearSongs()
        {
            dbContext.Songs.RemoveRange(dbContext.Songs);
        }

        //Saves the database
        public Task SaveChangesAsync()
        {
            return dbContext.SaveChangesAsync();
        }

        public IQueryable<Song> GetSongs()
        {
            return dbContext.Songs;
        }

        public Task<Song> FindSongAsync(int id)
        {
            return dbContext.Songs.FindAsync(id);
        }

        //Change the entity state when it is modified
        public void ChangeState(Song song)
        {
            dbContext.Entry(song).State = EntityState.Modified;
        }

        public void RemoveSong(Song song)
        {
            dbContext.Songs.Remove(song);
        }

        //Dispose the database connection
        internal void Dispose()
        {
            dbContext.Dispose();
        }
    }
}