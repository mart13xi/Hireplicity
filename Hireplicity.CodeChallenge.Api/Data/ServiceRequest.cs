using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hireplicity.CodeChallenge.Api.Data
{
    [Table("servicerequests")]
    public class ServiceRequest
    {
        [Column("id")]
        public Guid Id { get; set; }
        [Column("buildingcode")]
        public string BuildingCode { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("currentstatus")]
        public string CurrentStatus { get; set; }
        [Column("createdby")]
        public string CreatedBy { get; set; }
        [Column("createddate")]
        public DateTime CreatedDate { get; set; }
        [Column("lastmodifiedby")]
        public string LastModifiedBy { get; set; }
        [Column("lastmodifieddate")]
        public DateTime LastModifiedDate { get; set; }
    }
}
