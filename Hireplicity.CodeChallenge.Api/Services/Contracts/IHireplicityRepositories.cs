using Hireplicity.CodeChallenge.Api.Data;

namespace Hireplicity.CodeChallenge.Api.Services.Contracts
{
    public interface IHireplicityRepositories
    {
        Task<IEnumerable<ServiceRequest>> GetAllAsync();
        Task<ServiceRequest> GetByIdAsync(Guid Id);
        Task<bool> InsertAsync(ServiceRequest serviceRequest);
        bool UpdateAsync(ServiceRequest serviceRequest);
        bool DeleteAsync(ServiceRequest serviceRequest);
    }
}
