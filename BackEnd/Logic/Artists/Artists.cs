﻿using System.Linq;
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
        /// <param name="BandId"></param>
        /// <returns></returns>
        public async Task<List<Band>> GetBands(int? BandId) 
        {

            if (BandId != null) 
            {
                
                return await FMainDbContext.Bands
                    .AsNoTracking()
                    .Where(R => R.Id == BandId)
                    .Select(R => new Band 
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
                    .Select(R => new Band
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
        /// <param name="BandId"></param>
        /// <returns></returns>
        public async Task<List<Member>> GetMembers(int BandId) 
        {

            return await FMainDbContext.Members
                .AsNoTracking()
                .Where(R => R.BandId == BandId)
                .Select(R => new Member 
                { 
                    Id        = R.Id,
                    FirstName = R.FirstName,
                    LastName  = R.LastName,
                    Status    = R.IsPresent ? "Active" : "Past member"
                })
                .ToListAsync();

        }

        /// <summary>
        /// Return band details for given Band Id.
        /// </summary>
        /// <param name="BandId"></param>
        /// <returns></returns>
        public async Task<ReturnBandDetails> GetBandDetails(int BandId) 
        {

            var Members = await GetMembers(BandId);



        }

    }

}
