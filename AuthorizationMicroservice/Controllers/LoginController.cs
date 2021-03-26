using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorizationMicroservice.Repositories;
using AuthorizationMicroservice.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AuthorizationMicroservice.Controllers
{
    //https://localhost:44371/api/login/
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IJWTAuthenticationManager jWTAuthenticationManager;
        private ILoginRepository _repository;

        public LoginController(IJWTAuthenticationManager jWTAuthenticationManager,ILoginRepository repository)
        {
            this.jWTAuthenticationManager = jWTAuthenticationManager;
            _repository = repository;
        }

        [HttpGet("generateToken")]
        [AllowAnonymous]
        public string GenerateToken()
        {
            var token = jWTAuthenticationManager.Authenticate("Authorized","Admin0@123");
            return token;
        }

        [HttpPost("addnewuser")]
        [AllowAnonymous]
        public string AddNewUser([FromBody] UserCredentials user)
        {
            _repository.AddUser(user);
            return "Success";
        }

        [HttpPost("addnewemployee")]
        [AllowAnonymous]
        public string AddNewEmployee([FromBody] BankEmployeeLogin employee)
        {

            _repository.AddBankEmployee(employee);
            return "New Employee Login has been created";
        }

        [HttpPost("addnewcustomer")]
        [AllowAnonymous]
        public string AddNewCustomer([FromBody] CustomerLogin customer)
        {
            _repository.AddCustomer(customer);
            return "New Customer Login has been created";
        }

        [AllowAnonymous]
        [HttpPost("authenticateemployee")]
        public IActionResult AuthenticateEmployee([FromBody] BankEmployeeLogin employee)
        {
            BankEmployeeLogin bankEmployee = _repository.FindEmployee(employee);
            if (bankEmployee != null)
            {
                if (bankEmployee.EmployeeUsername != employee.EmployeeUsername && bankEmployee.EmployeePassword != employee.EmployeePassword)
                {
                    return Unauthorized();
                }
                else
                {
                    var token = jWTAuthenticationManager.Authenticate(employee.EmployeeUsername, employee.EmployeePassword);
                    if (token == null)
                        return Unauthorized();
                    return Ok(token);
                }
            }
            else
                return Unauthorized();
        }

        [AllowAnonymous]
        [HttpPost("authenticatecustomer")]
        public IActionResult AuthenticateCustomer([FromBody] CustomerLogin customer)
        {
            CustomerLogin customer1 = _repository.FindCustomer(customer);
            if(customer1 != null)
            {
                if(customer1.CustomerUsername != customer.CustomerUsername && customer1.CustomerPassword != customer1.CustomerPassword)
                {
                    return Unauthorized();
                }
                else
                {
                    var token = jWTAuthenticationManager.Authenticate(customer.CustomerUsername, customer.CustomerPassword);
                    if (token == null)
                        return Unauthorized();
                    return Ok(token);
                }
            }
            else
                return Unauthorized();
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserCredentials userCred)
        {
            var token = jWTAuthenticationManager.Authenticate(userCred.Username, userCred.Password);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }
    }
}
