using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorizationMicroservice.Models;

namespace AuthorizationMicroservice.Data
{
    public class LoginContext : DbContext
    {
        public LoginContext(DbContextOptions<LoginContext> options)
            : base(options)
        {
        }

        public DbSet<UserCredentials> Users { get; set; }

        public DbSet<BankEmployeeLogin> BankEmployeesLogin { get; set; }

        public DbSet<CustomerLogin> CustomersLogin { get; set; }
    }
}
