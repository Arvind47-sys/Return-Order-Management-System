using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Entities
{
    [Table("AppUser")]
    public class AppUser
    {
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public byte[] PasswordHash { get; set; }

        [Required]
        public byte[] PasswordSalt { get; set; }

        public ICollection<ProcessRequest> ProcessRequests { get; set; }

        public ICollection<ProcessResponse> ProcessResponses { get; set; }

    }
}