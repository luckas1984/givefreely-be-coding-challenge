using Affiliation.Domain.Dtos;
using Affiliation.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace AffiliationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly IReportsService _reportSertice;
        public ReportsController(IReportsService reportService)
        {
            _reportSertice = reportService ?? throw new ArgumentNullException(nameof(reportService)); ;
        }

        [HttpGet]
        [Route("commission")]
        public IEnumerable<ReferredCustomerDTO> Get() 
        {
            return _reportSertice.CommissionReporting();
        }
    }
}