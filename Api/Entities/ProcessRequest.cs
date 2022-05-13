using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Entities
{
    [Table("ProcessRequest")]
    public class ProcessRequest
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public long ContactNumber { get; set; }

        [Required]
        public string DefectiveComponentType { get; set; }

        [Required]
        public string DefectiveComponentName { get; set; }
        public int Quantity { get; set; }

        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }

    }
}