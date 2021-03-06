﻿using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SongLyrics.Shared.Dto;
using SongLyrics.Infrastructure.Database;

namespace SongLyrics.Logic.Artists
{
    public class Artists : IArtists
    {
        private readonly MainDbContext FMainDbContext;

        public Artists(MainDbContext AMainDbContext) 
            => FMainDbContext = AMainDbContext;

        /// <summary>
        /// Return list of bands/or band from the entire collection.
        /// </summary>
        /// <param name="AArtistId"></param>
        /// <param name="ACancellationToken"></param>
        /// <returns></returns>
        public async Task<List<ArtistDto>> GetArtists(int? AArtistId, CancellationToken ACancellationToken = default)
        {
            if (AArtistId != null) 
            {               
                return await FMainDbContext.Artists
                    .AsNoTracking()
                    .Where(AArtists => AArtists.Id == AArtistId)
                    .Select(AArtists => new ArtistDto 
                    { 
                        Id = AArtists.Id,
                        Name = AArtists.ArtistName
                    })
                    .ToListAsync(ACancellationToken);           
            }

            return await FMainDbContext.Artists
                .AsNoTracking()
                .Select(AArtists => new ArtistDto
                {
                    Id = AArtists.Id,
                    Name = AArtists.ArtistName
                })
                .ToListAsync(ACancellationToken);
        }

        /// <summary>
        /// Return bands members for given Band Id.
        /// </summary>
        /// <param name="AArtistId"></param>
        /// <param name="ACancellationToken"></param>
        /// <returns></returns>
        public async Task<List<MemberDto>> GetMembers(int AArtistId, CancellationToken ACancellationToken = default) 
        {
            return await FMainDbContext.Members
                .AsNoTracking()
                .Where(AMembers => AMembers.ArtistId == AArtistId)
                .Select(AMembers => new MemberDto 
                { 
                    Id = AMembers.Id,
                    FirstName = AMembers.FirstName,
                    LastName = AMembers.LastName,
                    Status = AMembers.IsPresent ? "Active" : "Past"
                })
                .ToListAsync(ACancellationToken);
        }

        /// <summary>
        /// Return band details for given Band Id.
        /// </summary>
        /// <param name="AArtistId"></param>
        /// <param name="ACancellationToken"></param>
        /// <returns></returns>
        public async Task<ReturnArtistDetailsDto> GetArtistDetails(int AArtistId, CancellationToken ACancellationToken = default) 
        {
            var LMembers = await GetMembers(AArtistId, ACancellationToken);
            var LResults = await FMainDbContext.ArtistsGeneres
                .Include(AArtistsGeneres => AArtistsGeneres.Artist)
                .Include(AArtistsGeneres => AArtistsGeneres.Genere)
                .AsNoTracking()
                .Where(AArtistsGeneres => AArtistsGeneres.ArtistId == AArtistId)
                .Select(AArtistsGeneres => new ReturnArtistDetailsDto
                {
                    Name = AArtistsGeneres.Artist.ArtistName,
                    Established = AArtistsGeneres.Artist.Established,
                    ActiveUntil = AArtistsGeneres.Artist.ActiveUntil,
                    Genere = AArtistsGeneres.Genere.Genere,
                    Members = LMembers
                })
                .ToListAsync(ACancellationToken);

            return LResults.Any() ? LResults.Single() : new ReturnArtistDetailsDto
            {
                Name = "n/a",
                Genere = "n/a",
                Established = DateTime.Now,
                ActiveUntil = DateTime.Now,
                Members = null
            };
        }
    }
}
