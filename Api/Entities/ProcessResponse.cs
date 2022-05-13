using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Entities
{
    [Table("ProcessResponse")]
    public class ProcessResponse
    {
        public int Id { get; set; }
        public double ProcessingCharge { get; set; }
        public double PackagingAndDeliveryCharge { get; set; }
        public DateTime DateOfDelivery { get; set; }
        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }
        public ProcessRequest ProcessRequest { get; set; }
        public int RequestId { get; set; }
    }
}