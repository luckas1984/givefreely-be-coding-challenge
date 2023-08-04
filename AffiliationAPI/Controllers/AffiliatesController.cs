using Affiliation.Domain.Models;
using Affiliation.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace AffiliationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AffiliatesController : ControllerBase
    {
        private readonly IAffiliatesService _affiliatesService;
        public AffiliatesController(IAffiliatesService affiliatesService)
        {
            _affiliatesService = affiliatesService?? throw new ArgumentNullException(nameof(affiliatesService));
        }

        [HttpGet]
        public IEnumerable<Affiliate> Get() 
        {
            return _affiliatesService.GetAll();
        }

        [HttpPost]
        public Affiliate Post(string name)
        {
            return _affiliatesService.Insert(name);
        }

        [HttpGet]
        [Route("{affiliate}/customers")]
        public IEnumerable<Customer> GetByAffiliate(string affiliate)
        {
            return _affiliatesService.GetCustomers(affiliate);
        }
    }
}