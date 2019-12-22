using System.Threading.Tasks;
using Orneholm.SverigesRadio.Api.Models;

namespace Orneholm.SverigesRadio.Api
{
    /// <summary>
    /// Sveriges Radio Open API Client.
    /// </summary>
    public interface ISverigesRadioApiClient
    {
        Task<ProgramDetailsResponse> GetProgramAsync(ProgramDetailsRequest request);
        Task<ProgramListResponse> GetProgramsAsync(ProgramListRequest request);
    }
}
