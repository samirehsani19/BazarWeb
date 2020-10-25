using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace myweb.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        //[Required, MinLength(5), MaxLength(30,ErrorMessage ="Username must be between 5 to 30 characters")]
        public string Username { get; set; }
        //[Required,RegularExpression(@"^[a-z0-9A-Z]{5,20}$")]
        public string Password { get; set; }
    }
}
