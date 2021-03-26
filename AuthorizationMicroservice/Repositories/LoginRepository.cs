using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorizationMicroservice.Data;
using AuthorizationMicroservice.Models;

namespace AuthorizationMicroservice.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private LoginContext _context;

        public LoginRepository(LoginContext context)
        {
            _context = context;
        }

        public void AddUser(UserCredentials user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }

        public void AddBankEmployee(BankEmployeeLogin employee)
        {
            _context.BankEmployeesLogin.Add(employee);
            _context.SaveChanges();
        }

        public void AddCustomer(CustomerLogin customer)
        {
            _context.CustomersLogin.Add(customer);
            _context.SaveChanges();
        }

        public BankEmployeeLogin FindEmployee(BankEmployeeLogin bankEmployee)
        {
            BankEmployeeLogin bankEmployee1 = _context.BankEmployeesLogin.SingleOrDefault(e => (e.EmployeeUsername == bankEmployee.EmployeeUsername && e.EmployeePassword == e.EmployeePassword));
            return bankEmployee1;
        }

        public CustomerLogin FindCustomer(CustomerLogin customer)
        {
            CustomerLogin customer1 = _context.CustomersLogin.SingleOrDefault(c => (c.CustomerUsername == customer.CustomerUsername && c.CustomerPassword == customer.CustomerPassword));
            return customer1;
        }
    }
}
