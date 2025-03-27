using Hireplicity.CodeChallenge.Api.Data;
using Hireplicity.CodeChallenge.Api.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Hireplicity.CodeChallenge.Api.Services.Concretes
{
    public class HireplicityRepositories : IHireplicityRepositories
    {
        private readonly HirepilicityDbContext _context;
        public HireplicityRepositories(HirepilicityDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ServiceRequest>> GetAllAsync()
        {
            return await _context.ServiceRequests.ToListAsync();
        }

        public async Task<ServiceRequest> GetByIdAsync(Guid Id)
        {
            return await _context.ServiceRequests.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<bool> InsertAsync(ServiceRequest serviceRequest)
        {
            await _context.ServiceRequests.AddAsync(serviceRequest);
            return true;
        }

        public bool UpdateAsync(ServiceRequest serviceRequest)
        {
            _context.ServiceRequests.Update(serviceRequest);
            return true;
        }

        public bool DeleteAsync(ServiceRequest serviceRequest)
        {
            _context.ServiceRequests.Remove(serviceRequest);
            return true;
        }
    }
}
