using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Company
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        [ForeignKey(nameof(Address))]
        public short AddressId { get; set; }

        public Address Address { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
