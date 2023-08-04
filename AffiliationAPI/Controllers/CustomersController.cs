using Affiliation.Domain.Dtos;
using Affiliation.Domain.Models;
using Affiliation.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace AffiliationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService?? throw new ArgumentNullException(nameof(customerService));
        }

        [HttpPost]
        public Customer Post(CustomerDto customer)
        {
            return _customerService.Affiliation(customer);
        }
    }
}