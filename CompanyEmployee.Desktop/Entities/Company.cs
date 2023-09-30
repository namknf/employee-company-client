namespace Entities
{
    public class Company
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public short AddressId { get; set; }

        public Address Address { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
