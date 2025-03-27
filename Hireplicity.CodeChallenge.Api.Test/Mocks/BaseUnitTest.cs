using Hireplicity.CodeChallenge.Api.Controllers;
using Hireplicity.CodeChallenge.Api.Services.Concretes;
using Hireplicity.CodeChallenge.Api.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hireplicity.CodeChallenge.Api.Test.Mocks
{
    [TestClass]
    public abstract class BaseUnitTest
    {
        public ServiceProvider ContainerService;

        [TestInitialize]
        public void Setup()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddScoped(p => MockHirepilicityDbContext.CreateInMemoryContextWithData(Guid.NewGuid().ToString()));
            services.AddScoped<IHireplicityRepositories, HireplicityRepositories>();
            services.AddScoped<ServiceRequestController>();

            ContainerService = services.BuildServiceProvider();
        }

        [TestCleanup]
        public void Cleanup() { }
    }
}
