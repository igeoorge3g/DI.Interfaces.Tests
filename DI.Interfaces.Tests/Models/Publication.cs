using DI.Interfaces.Tests.Interfaces;

namespace DI.Interfaces.Tests.Models
{
    /// <summary>
    /// My custom Product
    /// </summary>
    public class Publication : IEntity
    {
        public int Id { get; init; }
        public string Identifier { get; set; }
        public string Name { get; set; }
        public int SalesChannelId { get; set; }
    }
}
