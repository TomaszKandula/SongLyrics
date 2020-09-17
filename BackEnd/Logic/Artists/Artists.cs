using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using BackEnd.Models.Json;
using BackEnd.Models.Database;

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
                
                return await FMainDbContext.Bands
                    .AsNoTracking()
                    .Where(R => R.Id == ArtistId)
                    .Select(R => new Artist 
                    { 
                        Id   = R.Id,
                        Name = R.BandName
                    })
                    .ToListAsync();
            
            }
            else            
            {

                return await FMainDbContext.Bands
                    .AsNoTracking()
                    .Select(R => new Artist
                    {
                        Id   = R.Id,
                        Name = R.BandName
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
                .Where(R => R.BandId == ArtistId)
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
        public async Task<ReturnArtistDetails> GetBandDetails(int ArtistId) 
        {

            var Members = await GetMembers(ArtistId);

            return (await FMainDbContext.BandsGeneres
                .Include(R => R.Band)
                .Include(R => R.Genere)
                .AsNoTracking()
                .Where(R => R.BandId == ArtistId)
                .Select(R => new ReturnArtistDetails 
                {
                    Name        = R.Band.BandName,
                    Established = R.Band.Established,
                    ActiveUntil = R.Band.ActiveUntil,
                    Genere      = R.Genere.Genere,
                    Members     = Members
                })
                .ToListAsync())
                .Single();

        }

    }

}
