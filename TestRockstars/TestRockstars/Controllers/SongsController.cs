using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using TestRockstars.DAL;
using TestRockstars.Models;
using TestRockstars.Repositories;

namespace TestRockstars.Controllers
{
    public class SongsController : ApiController
    {
        private SongsRepository dbRepository = new SongsRepository(new DatabaseContext());

        // GET: api/Songs
        public IQueryable<Song> GetSongs()
        {
            return dbRepository.GetSongs();
        }

        // GET: api/Songs/5
        [ResponseType(typeof(Song))]
        public async Task<IHttpActionResult> GetSong(int id)
        {
            Song song = await dbRepository.FindSongAsync(id);
            if (song == null)
            {
                return NotFound();
            }

            return Ok(song);
        }

        // PUT: api/Songs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSong(int id, Song song)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != song.Id)
            {
                return BadRequest();
            }

            dbRepository.ChangeState(song);

            try
            {
                await dbRepository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Songs
        [ResponseType(typeof(Song))]
        public async Task<IHttpActionResult> PostSong(Song song)
        {
            if (dbRepository.GetSongs().Where(a => a.Name.Equals(song.Name)).Count() > 0)
            {
                return BadRequest("That name already exists!");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            dbRepository.AddSong(song);
            await dbRepository.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = song.Id }, song);
        }

        // DELETE: api/Songs/5
        [ResponseType(typeof(Song))]
        public async Task<IHttpActionResult> DeleteSong(int id)
        {
            Song song = await dbRepository.FindSongAsync(id);
            if (song == null)
            {
                return NotFound();
            }

            dbRepository.RemoveSong(song);
            await dbRepository.SaveChangesAsync();

            return Ok(song);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SongExists(int id)
        {
            return dbRepository.GetSongs().Count(e => e.Id == id) > 0;
        }
    }
}