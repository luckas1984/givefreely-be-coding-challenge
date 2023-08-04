using Affiliation.Domain.Models;

namespace Affiliation.Domain.Services
{
    public interface IAffiliatesService
    {
        Affiliate Insert(string name);

        IEnumerable<Affiliate> GetAll();

        IEnumerable<Customer> GetCustomers(string affiliate);
    }
}
