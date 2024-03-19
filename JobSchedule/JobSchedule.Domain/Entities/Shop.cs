using System.Diagnostics.CodeAnalysis;

namespace JobSchedule.Domain.Entities
{
    public class Shop : BaseEntity
    {
        public Shop() { }
        [SetsRequiredMembers]
        public Shop(string name, string? telephone, string? address)
        {
            Name = name;
            Telephone = telephone;
            Address = address;
        }

        public required string Name { get; set; }
        public string? Telephone { get; set; }
        public string? Address { get; set; }
    }
}
