using Hireplicity.CodeChallenge.Api.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Hireplicity.CodeChallenge.Api.Test.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hireplicity.CodeChallenge.Api.Data;

namespace Hireplicity.CodeChallenge.Api.Test.Controllers
{
    [TestClass]
    public class UnitTest_ServiceRequestController_Test : BaseUnitTest
    {
        [TestMethod]
        public async Task UnitTest_ServiceRequestController_001_GetAll_Positive()
        {
            ServiceRequestController controller = ActivatorUtilities.CreateInstance<ServiceRequestController>(ContainerService);

            IActionResult actionResult = await controller.GetAll();

            OkResult result = actionResult as OkResult;
            Assert.IsNotNull(controller);
        }

        [TestMethod]
        [DataRow("2db2e186-194d-4058-9acf-f645ac0954ca")]
        public async Task UnitTest_ServiceRequestController_002_GetById_Positive(string id)
        {
            ServiceRequestController controller = ActivatorUtilities.CreateInstance<ServiceRequestController>(ContainerService);

            IActionResult actionResult = await controller.GetById(Guid.Parse(id));

            OkObjectResult result = actionResult as OkObjectResult;
            Assert.AreEqual(200, result.StatusCode);
            Assert.IsNotNull(controller);
        }

        [TestMethod]
        [DataRow("2db2e186-194d-4058-9acf-f645ac0954c2", "COH2", "Turn off", "Created", "Rey", "2025-03-27T20:15:51", "Mart", "2025-03-27T20:25:51")]
        public async Task UnitTest_ServiceRequestController_003_Insert_Positive(string id, string buildingcode, string description, string currentstatus, string createdby, string createddate, string lastmodifiedby, string lastmodifieddate)
        {
            ServiceRequest serviceRequest = new ServiceRequest
            {
                Id = Guid.Parse(id),
                BuildingCode = buildingcode,
                Description = description,
                CurrentStatus = currentstatus,
                CreatedBy = createddate,
                CreatedDate = Convert.ToDateTime(createddate),
                LastModifiedBy = lastmodifiedby,
                LastModifiedDate = Convert.ToDateTime(lastmodifieddate)
            };

            ServiceRequestController controller = ActivatorUtilities.CreateInstance<ServiceRequestController>(ContainerService);

            IActionResult actionResult = await controller.Insert(serviceRequest);

            CreatedAtActionResult result = actionResult as CreatedAtActionResult;
            Assert.AreEqual(201, result.StatusCode);
            Assert.IsNotNull(controller);
        }

        [TestMethod]
        [DataRow("2cd93117-4615-4962-be09-42839a703e72", "COH2", "Turn off", "Created", "Mart", "2025-03-27T20:15:51", "Rey", "2025-03-27T20:25:51")]
        public async Task UnitTest_ServiceRequestController_004_Update_Positive(string id, string buildingcode, string description, string currentstatus, string createdby, string createddate, string lastmodifiedby, string lastmodifieddate)
        {
            ServiceRequest serviceRequest = new ServiceRequest
            {
                Id = Guid.Parse(id),
                BuildingCode = buildingcode,
                Description = description,
                CurrentStatus = currentstatus,
                CreatedBy = createddate,
                CreatedDate = Convert.ToDateTime(createddate),
                LastModifiedBy = lastmodifiedby,
                LastModifiedDate = Convert.ToDateTime(lastmodifieddate)
            };

            ServiceRequestController controller = ActivatorUtilities.CreateInstance<ServiceRequestController>(ContainerService);

            IActionResult actionResult = await controller.Update(serviceRequest.Id, serviceRequest);

            OkObjectResult result = actionResult as OkObjectResult;
            Assert.AreEqual(200, result.StatusCode);
            Assert.IsNotNull(controller);
        }

        [TestMethod]
        [DataRow("2db2e186-194d-4058-9acf-f645ac0954ca")]
        public async Task UnitTest_ServiceRequestController_005_Delete_Positive(string id)
        {
            ServiceRequestController controller = ActivatorUtilities.CreateInstance<ServiceRequestController>(ContainerService);

            IActionResult actionResult = await controller.Delete(Guid.Parse(id));

            CreatedAtActionResult result = actionResult as CreatedAtActionResult;
            Assert.AreEqual(201, result.StatusCode);
            Assert.IsNotNull(controller);
        }
    }
}
