using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using BackEnd.Models.Json;
using System;
using BackEnd.Controllers.Artists.Models;
using BackEnd.Database;

namespace BackEnd.Logic.Artists
{

    public class Artists : IArtists
    {

        private readonly MainDbContext FMainDbContext;

        public Artists(MainDbContext AMainDbContext) 
        {
            FMainDbContext = AMainDbContext;
        }

        /// <summary>
        /// Return list of bands/or band from the entire collection.
        /// </summary>
        /// <param name="ArtistId"></param>
        /// <returns></returns>
        public async Task<List<Artist>> GetArtists(int? ArtistId) 
        {

            if (ArtistId != null) 
            {
                
                return await FMainDbContext.Artists
                    .AsNoTracking()
                    .Where(R => R.Id == ArtistId)
                    .Select(R => new Artist 
                    { 
                        Id   = R.Id,
                        Name = R.ArtistName
                    })
                    .ToListAsync();
            
            }
            else            
            {

                return await FMainDbContext.Artists
                    .AsNoTracking()
                    .Select(R => new Artist
                    {
                        Id   = R.Id,
                        Name = R.ArtistName
                    })
                    .ToListAsync();

            }

        }

        /// <summary>
        /// Return bands members for given Band Id.
        /// </summary>
        /// <param name="ArtistId"></param>
        /// <returns></returns>
        public async Task<List<Member>> GetMembers(int ArtistId) 
        {

            return await FMainDbContext.Members
                .AsNoTracking()
                .Where(R => R.ArtistId == ArtistId)
                .Select(R => new Member 
                { 
                    Id        = R.Id,
                    FirstName = R.FirstName,
                    LastName  = R.LastName,
                    Status    = R.IsPresent ? "Active" : "Past"
                })
                .ToListAsync();

        }

        /// <summary>
        /// Return band details for given Band Id.
        /// </summary>
        /// <param name="ArtistId"></param>
        /// <returns></returns>
        public async Task<ReturnArtistDetails> GetArtistDetails(int ArtistId) 
        {

            var Members = await GetMembers(ArtistId);

            var Results = await FMainDbContext.ArtistsGeneres
                .Include(R => R.Artist)
                .Include(R => R.Genere)
                .AsNoTracking()
                .Where(R => R.ArtistId == ArtistId)
                .Select(R => new ReturnArtistDetails
                {
                    Name = R.Artist.ArtistName,
                    Established = R.Artist.Established,
                    ActiveUntil = R.Artist.ActiveUntil,
                    Genere = R.Genere.Genere,
                    Members = Members
                })
                .ToListAsync();

            return Results.Any() ? Results.Single() : new ReturnArtistDetails()
            {
                Name        = "n/a",
                Genere      = "n/a",
                Established = DateTime.Now,
                ActiveUntil = DateTime.Now,
                Members     = null
            };

        }

    }

}
