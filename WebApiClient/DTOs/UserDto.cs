using System.ComponentModel.DataAnnotations;
using Tools.Enums;

namespace WebApiClient.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        //TODO: Consider which fields should be required.
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int PostCode { get; set; }
        public string PhoneNumber { get; set; }
        public Role Role { get; set; }
    }
}
