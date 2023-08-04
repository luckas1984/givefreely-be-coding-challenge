
using System.Text.Json.Serialization;

namespace Affiliation.Domain.Models
{
    public class Affiliate: EntityBase
    {
        public string Name { get; set; }
        public List<Customer> Customers { get; } = new();
    }
}
