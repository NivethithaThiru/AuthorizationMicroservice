using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationMicroservice.Models
{
    public class BankEmployeeLogin
    {
        [Key]
        public int BankEmployeeId { get; set; }

        [Required]
        public string EmployeeUsername { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string EmployeePassword { get; set; }

    }
}
