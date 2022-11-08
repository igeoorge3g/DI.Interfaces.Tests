using DI.Interfaces.Tests.Interfaces;

namespace DI.Interfaces.Tests.Models
{
    public class SalesChannel : IEntity
    {
        public int Id { get; init; }
        public string Name { get; set; }

    }
}
