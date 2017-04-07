using System.ComponentModel.DataAnnotations;

namespace Repositories.Models.ViewModels
{
    public class ContactViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        public bool IsActive { get; set; }
    }
}