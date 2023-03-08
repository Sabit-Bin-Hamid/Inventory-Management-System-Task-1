using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace StudentModule.Models.Domain
{
    public class Student
    {
        public Guid Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Required Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Required First Name")]
        public string UserFirstName { get; set; }

        [Required(ErrorMessage ="Required Last Name")]
        public string UserLastName { get; set; }

        [Required(ErrorMessage = "Required  Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Required Phone")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Required Address")]
        public string Address { get; set; }

    }
}
