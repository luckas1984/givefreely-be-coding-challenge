using Affiliation.Domain;
using Affiliation.Domain.Models;
using Affiliation.Domain.Services;

namespace Affiliation.Infrastructure.Services
{
    public class AffiliatesService : IAffiliatesService
    {
        public readonly IRepository<Affiliate> _affiliateRepo;
        
        public AffiliatesService(IUnitOfWork unitOfWork)
        {
            var uow = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

            _affiliateRepo = uow.Repository<Affiliate>();
        }

        public IEnumerable<Affiliate> GetAll()
        {
            return _affiliateRepo.All();
        }

        public IEnumerable<Customer> GetCustomers(string affiliate)
        {
            return _affiliateRepo.All()?.FirstOrDefault(a => a.Name.Equals(affiliate))?.Customers;
        }

        public Affiliate Insert(string name)
        {
            return _affiliateRepo.Insert(new Affiliate() { Name = name});
        }
    }
}
