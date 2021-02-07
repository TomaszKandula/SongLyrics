using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using SongLyrics.Shared.Dto;

namespace SongLyrics.Logic.Artists
{
    public interface IArtists
    {
        /// <summary>
        /// Return list of bands from the entire collection.
        /// </summary>
        /// <param name="AArtistId"></param>
        /// <returns></returns>
        Task<List<ArtistDto>> GetArtists(int? AArtistId, CancellationToken ACancellationToken = default);

        /// <summary>
        /// Return bands members for given Band Id.
        /// </summary>
        /// <param name="AArtistId"></param>
        /// <returns></returns>
        Task<List<MemberDto>> GetMembers(int AArtistId, CancellationToken ACancellationToken = default);

        /// <summary>
        /// Return band details for given Band Id.
        /// </summary>
        /// <param name="AArtistId"></param>
        /// <returns></returns>
        Task<ReturnArtistDetailsDto> GetArtistDetails(int AArtistId, CancellationToken ACancellationToken = default);
    }
}
