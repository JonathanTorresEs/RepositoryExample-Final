using System.ComponentModel.DataAnnotations;

namespace Repositories.Models.ViewModels
{
    public class CreateContactViewModel
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        public bool IsActive { get; set; }
    }
}