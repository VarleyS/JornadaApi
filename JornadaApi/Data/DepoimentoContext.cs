using JornadaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JornadaApi.Data
{
    public class DepoimentoContext : DbContext
    {
        public DepoimentoContext(DbContextOptions<DepoimentoContext> opts) : base(opts)
        {
        }

        public DbSet<Depoimento> Depoimentos { get; set; }
    }
}
