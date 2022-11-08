using DI.Interfaces.Core.Interfaces;
using DI.Interfaces.Core.Models;
using DI.Interfaces.Infrastructure.Persistence;
using DI.Interfaces.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DI.Interfaces.Core.Repositories
{
    public class PublicationRepository : AbstractRepository<int, Publication>, IPublicationRepository
    {
        private readonly ApplicationDbContext _context;
        public PublicationRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Publication> FindByIdentifier(string identifier)
        {
            return await _context.Publications.FirstOrDefaultAsync(e => e.Identifier == identifier);
        }

    }
}
