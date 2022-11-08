using DI.Interfaces.Core.Interfaces;

namespace DI.Interfaces.Core.Models
{
    public class SalesChannel : IEntity
    {
        public int Id { get; init; }
        public string Name { get; set; }

    }
}
