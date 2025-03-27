using Hireplicity.CodeChallenge.Api.Data;
using Hireplicity.CodeChallenge.Api.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Hireplicity.CodeChallenge.Api.Services.Concretes
{
    public class HireplicityRepositories : IHireplicityRepositories
    {
        private readonly HirepilicityDbContext _dbContext;
        public HireplicityRepositories(HirepilicityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ServiceRequest>> GetAllAsync()
        {
            return await _dbContext.ServiceRequests.AsNoTracking().ToListAsync();
        }

        public async Task<ServiceRequest> GetByIdAsync(Guid id)
        {
            return await _dbContext.ServiceRequests.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ServiceRequest> InsertAsync(ServiceRequest serviceRequest)
        {
            await _dbContext.ServiceRequests.AddAsync(serviceRequest);
            await _dbContext.SaveChangesAsync();
            return serviceRequest;
        }

        public async Task<ServiceRequest> UpdateAsync(Guid id, ServiceRequest serviceRequest)
        {
            ServiceRequest serviceRequestResult = await _dbContext.ServiceRequests.FirstOrDefaultAsync(x => x.Id == id);
            if (serviceRequestResult == null)
            {
                return null;
            }

            serviceRequestResult.BuildingCode = serviceRequest.BuildingCode;
            serviceRequestResult.Description = serviceRequest.Description;
            serviceRequestResult.CurrentStatus = serviceRequest.CurrentStatus;
            serviceRequestResult.CreatedBy = serviceRequest.CreatedBy;
            serviceRequestResult.CreatedDate = serviceRequest.CreatedDate;
            serviceRequestResult.LastModifiedBy = serviceRequest.LastModifiedBy;
            serviceRequestResult.LastModifiedDate = serviceRequest.LastModifiedDate;

            _dbContext.ServiceRequests.Update(serviceRequestResult);
            await _dbContext.SaveChangesAsync();
            return serviceRequest;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            ServiceRequest serviceRequestResult = await _dbContext.ServiceRequests.FirstOrDefaultAsync(x => x.Id == id);
            if (serviceRequestResult == null)
            {
                return false;
            }

            _dbContext.ServiceRequests.Remove(serviceRequestResult);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
