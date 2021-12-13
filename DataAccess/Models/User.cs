using System.ComponentModel;
using Tools.Enums;

namespace DataAccess.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        [Description("password_hash_salt")]
        public string Password { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        [Description("post_code")]
        public int PostCode { get; set; }
        [Description("phone_number")]
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
    }
}