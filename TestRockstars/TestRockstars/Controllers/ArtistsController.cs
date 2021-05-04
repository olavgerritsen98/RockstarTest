using System;
using System.Collections.Generic;
using System.Data;
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
    public class ArtistsController : ApiController
    {
        private ArtistsRepository artistRepository = new ArtistsRepository( new DatabaseContext());

        // GET: api/Artists
        public IQueryable<Artist> GetArtists()
        {
            return artistRepository.GetArtists();
        }

        // GET: api/Artists/5
        [ResponseType(typeof(Artist))]
        public async Task<IHttpActionResult> GetArtist(int id)
        {
            Artist artist = await artistRepository.FindArtistAsync(id);

            if (artist == null)
            {
                return NotFound();
            }

            return Ok(artist);
        }

        // PUT: api/Artists/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutArtist(int id, Artist artist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != artist.Id)
            {
                return BadRequest();
            }

            artistRepository.ChangeState(artist);

            try
            {
                await artistRepository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtistExists(id))
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

        // POST: api/Artists
        [ResponseType(typeof(Artist))]
        public async Task<IHttpActionResult> PostArtist(Artist artist)
        {
            if (artistRepository.GetArtists().Where(a => a.Name.Equals(artist.Name)).Count() > 0)
            {
                return BadRequest("That name already exists!");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            artistRepository.AddArtist(artist);
            await artistRepository .SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = artist.Id }, artist);
        }

        // DELETE: api/Artists/5
        [ResponseType(typeof(Artist))]
        public async Task<IHttpActionResult> DeleteArtist(int id)
        {
            Artist artist = await artistRepository.FindArtistAsync(id);
            if (artist == null)
            {
                return NotFound();
            }

            artistRepository.RemoveArtist(artist);
            await artistRepository.SaveChangesAsync();

            return Ok(artist);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                artistRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ArtistExists(int id)
        {
            return artistRepository.GetArtists().Count(e => e.Id == id) > 0;
        }
    }
}