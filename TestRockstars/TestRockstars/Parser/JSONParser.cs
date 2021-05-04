using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using TestRockstars.Models;

namespace TestRockstars.Parser
{
    public class JSONParser
    {
        List<Artist> artists = new List<Artist>();
        List<Song> songs = new List<Song>();
        public JSONParser()
        {
            ParseJSON();
        }

        public void ParseJSON()
        {
            using (WebClient wc = new WebClient())
            {
                var artistJSON = wc.DownloadString("https://www.teamrockstars.nl/sites/default/files/artists.json");
                var songJSON = wc.DownloadString("https://www.teamrockstars.nl/sites/default/files/songs.json");

                songs = JsonConvert.DeserializeObject<List<Song>>(songJSON);
                artists = JsonConvert.DeserializeObject<List<Artist>>(artistJSON);

                songs = songs.Where(a => {
                    if (a.Year >= 2016 || !a.Genre.Contains("Metal"))
                    {
                        return false;
                    }

                    return artists.Select(artist => artist.Name).Contains(a.Artist);
                }).ToList();

                artists = songs.Select(song =>
                {
                    return artists.FirstOrDefault(b => b.Name.Equals(song.Artist));
                }).ToList();
            }
        }

        public List<Song> GetSongs()
        {
            return songs;
        }

        public List<Artist> GetArtists()
        {
            return artists;
        }
    }
}