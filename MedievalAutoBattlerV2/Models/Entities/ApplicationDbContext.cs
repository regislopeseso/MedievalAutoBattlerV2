using Microsoft.EntityFrameworkCore;

namespace MedievalAutoBattlerV2.Models.Entities
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
