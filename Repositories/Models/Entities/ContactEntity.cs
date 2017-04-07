using System.ComponentModel.DataAnnotations;

namespace Repositories.Models.Entities
{
    public class ContactEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        public bool IsActive { get; set; }
    }
}