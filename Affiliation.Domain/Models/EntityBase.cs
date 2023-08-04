using System.ComponentModel.DataAnnotations;

namespace Affiliation.Domain.Models
{
    public abstract class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}
