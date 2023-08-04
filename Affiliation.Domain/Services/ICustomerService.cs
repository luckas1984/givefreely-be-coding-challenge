using Affiliation.Domain.Dtos;
using Affiliation.Domain.Models;

namespace Affiliation.Domain.Services
{
    public interface ICustomerService
    {
        public Customer Affiliation(CustomerDto customerDto);
    }
}
