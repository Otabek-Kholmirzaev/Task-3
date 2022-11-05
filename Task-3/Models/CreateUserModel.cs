using System.ComponentModel.DataAnnotations;

namespace Task_3.Models
{

    public class CreateUserModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Roles { get; set; }
    }
}
