using Hireplicity.CodeChallenge.Api.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hireplicity.CodeChallenge.Api.Test.Mocks
{
    public class MockHirepilicityDbContext
    {
        public static HirepilicityDbContext CreateInMemoryContextWithData(string dbname)
        {
            var options = new DbContextOptionsBuilder<HirepilicityDbContext>()
                .UseInMemoryDatabase(dbname)
                .Options;
            var context = new HirepilicityDbContext(options);

            context.ServiceRequests.AddRange(
                new ServiceRequest
                {
                    Id = Guid.Parse("2db2e186-194d-4058-9acf-f645ac0954ca"),
                    BuildingCode = "COH",
                    Description = "Please turn up",
                    CurrentStatus = "Created",
                    CreatedBy = "Reymart",
                    CreatedDate = DateTime.Now,
                    LastModifiedBy = "Reymart S",
                    LastModifiedDate = DateTime.Now,
                },
                new ServiceRequest
                {
                    Id = Guid.Parse("2cd93117-4615-4962-be09-42839a703e72"),
                    BuildingCode = "COJ",
                    Description = "Please turn up",
                    CurrentStatus = "Created",
                    CreatedBy = "Reymart",
                    CreatedDate = DateTime.Now,
                    LastModifiedBy = "Reymart S",
                    LastModifiedDate = DateTime.Now,
                });

            context.SaveChanges();
            return context;
        }
    }
}
