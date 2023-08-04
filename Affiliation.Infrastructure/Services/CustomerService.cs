using Affiliation.Domain;
using Affiliation.Domain.Dtos;
using Affiliation.Domain.Models;
using Affiliation.Domain.Services;

namespace Affiliation.Infrastructure.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _customerRepo;
        private readonly IRepository<Affiliate> _affiliateRepo;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            var uow = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _customerRepo = uow.Repository<Customer>();
            _affiliateRepo = uow.Repository<Affiliate>();
        }

        public Customer Affiliation(CustomerDto customerDto)
        {
            var customer = new Customer() { 
                Name = customerDto.Name
            };
            var affiliate = _affiliateRepo.Get(customerDto.AffiliateId);
            customer.Affilations.Add(affiliate);

            return _customerRepo.Insert(customer);
        }
    }
}
