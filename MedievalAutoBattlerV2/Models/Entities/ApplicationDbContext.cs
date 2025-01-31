using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace MedievalAutoBattlerV2.Models.Entities
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        
        public DbSet<Card> Cards { get; set; }
    }
}
