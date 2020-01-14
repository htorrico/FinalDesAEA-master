using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }


        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        //[DefaultValue(true)]
        [DefaultValue("True")]
        public bool State { get; set; }


        public DateTime CreateAt { get; set; }

        public string Role { get; set; }

    }
}
