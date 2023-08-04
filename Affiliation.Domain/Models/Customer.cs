
using System.Text.Json.Serialization;

namespace Affiliation.Domain.Models
{
    public class Customer: EntityBase
    {
        public string Name { get; set; }
        public List<Affiliate> Affilations { get; } = new();

    }
}
