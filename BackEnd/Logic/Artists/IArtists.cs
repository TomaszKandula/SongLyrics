using System.Threading.Tasks;
using System.Collections.Generic;
using BackEnd.Models.Json;

namespace BackEnd.Logic.Artists
{

    public interface IArtists
    {

        /// <summary>
        /// Return list of bands from the entire collection.
        /// </summary>
        /// <param name="BandId"></param>
        /// <returns></returns>
        Task<List<Band>> GetBands(int? BandId);

        /// <summary>
        /// Return bands members for given Band Id.
        /// </summary>
        /// <param name="BandId"></param>
        /// <returns></returns>
        Task<List<Member>> GetMembers(int BandId);

        /// <summary>
        /// Return band details for given Band Id.
        /// </summary>
        /// <param name="BandId"></param>
        /// <returns></returns>
        Task<ReturnBandDetails> GetBandDetails(int BandId);

    }

}
