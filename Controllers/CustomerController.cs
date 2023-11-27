using BooksStoreWebAPI.Custom_Action_Filter;
using BooksStoreWebAPI.Models;
using BooksStoreWebAPI.Repository.Customer_Repository;
using BooksStoreWebAPI.Repository.Menu_Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksStoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> AddCustomer([FromBody] Customer customer)
        {
            var result = await customerRepository.AddCustomer(customer);
            if (customer == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPut]
        [Route("{customerId}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateCustomer([FromRoute] int customerId, [FromBody] Customer customer)
        {
            var result = await customerRepository.UpdateCustomer(customerId, customer);
            if (result == null)
            {
                return NotFound("No Results Found");
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomer()
        {
            var result = await customerRepository.GetAllCustomers();
            return Ok(result);

        }

        [HttpGet]
        [Route("{customerId}")]
        public async Task<IActionResult> CetCustomerById([FromRoute] int customerId)
        {
            var result = await customerRepository.GetCustomerById(customerId);
            if (result == null)
            {
                return NotFound("No Results Found");
            }
            return Ok(result);

        }

        [HttpDelete]
        [Route("{customerId}")]
        public async Task<IActionResult> DeleteMenu([FromRoute] int customerId)
        {
            var result = await customerRepository.DeleteCustomer(customerId);
            if (result == null)
            {
                return BadRequest("No Results Found");
            }

            return Ok(result);

        }
    
    }
}
