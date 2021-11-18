using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
}
