using Affiliation.Domain;
using Affiliation.Domain.Dtos;
using Affiliation.Domain.Models;
using Affiliation.Domain.Services;

namespace Affiliation.Infrastructure.Services
{
    public class ReportsService : IReportsService
    {
        private readonly IRepository<Affiliate> _affiliateRepo;
        public ReportsService(IUnitOfWork unitOfWork)
        {
            var uow = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _affiliateRepo = uow.Repository<Affiliate>();
        }

        public IEnumerable<ReferredCustomerDTO> CommissionReporting()
        {
            var report = from affiliation in _affiliateRepo.All()
                         select new ReferredCustomerDTO()
                         {
                             Affiliate = affiliation.Name,
                             ReferredCustomers = affiliation.Customers.Count
                         };

            return report;
        }
    }
}
