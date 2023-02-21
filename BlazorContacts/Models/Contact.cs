using System.ComponentModel.DataAnnotations;

namespace BlazorContacts.Models
{
    public class Contact
    {
        public Guid Id { get; set; }

        [Required]
        public string FullName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        public long Phone { get; set; }
        [Required]
        public string Address { get; set; }

    }
}
