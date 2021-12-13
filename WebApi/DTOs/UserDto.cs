using Tools.Enums;

namespace WebApi.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int PostCode { get; set; }
        public string PhoneNumber { get; set; }
        public Role Role { get; set; }
    }
}
