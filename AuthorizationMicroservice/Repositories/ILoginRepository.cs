using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorizationMicroservice.Models;

namespace AuthorizationMicroservice.Repositories
{
    public interface ILoginRepository
    {
        void AddUser(UserCredentials user);

        void AddBankEmployee(BankEmployeeLogin bankEmployee);

        void AddCustomer(CustomerLogin customer);

        public BankEmployeeLogin FindEmployee(BankEmployeeLogin bankEmployee);

        public CustomerLogin FindCustomer(CustomerLogin customer);
    }
}
