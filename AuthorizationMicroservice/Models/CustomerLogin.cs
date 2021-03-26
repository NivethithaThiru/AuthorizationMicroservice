using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationMicroservice.Models
{
    public class CustomerLogin
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        public string CustomerUsername { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string CustomerPassword { get; set; }

    }
}
