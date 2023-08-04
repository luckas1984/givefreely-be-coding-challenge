
using Affiliation.Domain.Dtos;

namespace Affiliation.Domain.Services
{
    public interface IReportsService
    {
        public IEnumerable<ReferredCustomerDTO> CommissionReporting();
    }
}
