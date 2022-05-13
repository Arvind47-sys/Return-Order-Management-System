using System.ComponentModel.DataAnnotations;


namespace Api.DTOs
{
    public class ProcessRequestDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public long ContactNumber { get; set; }

        [Required]
        public string DefectiveComponentType { get; set; }

        [Required]
        public string DefectiveComponentName { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}