using Modernization_SARFAB_Backend.Application.DTOs.Operations;

namespace Modernization_SARFAB_Backend.Application.Interfaces.Operations;

public interface IRequesterRepository
{
    Task<(IEnumerable<RequesterDTO> Data, int TotalPages, int TotalRecords)> GetRequestersAsync(string searchTerm = null, int page = 1, int pageSize = 10);
}
