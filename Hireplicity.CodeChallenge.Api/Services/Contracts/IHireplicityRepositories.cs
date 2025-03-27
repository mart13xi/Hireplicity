using Hireplicity.CodeChallenge.Api.Data;

namespace Hireplicity.CodeChallenge.Api.Services.Contracts
{
    public interface IHireplicityRepositories
    {
        Task<IEnumerable<ServiceRequest>> GetAllAsync();
        Task<ServiceRequest> GetByIdAsync(Guid id);
        Task<ServiceRequest> InsertAsync(ServiceRequest serviceRequest);
        Task<ServiceRequest> UpdateAsync(Guid id, ServiceRequest serviceRequest);
        Task<bool> DeleteAsync(Guid id);
    }
}
