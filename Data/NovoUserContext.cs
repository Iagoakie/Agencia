using Agencia1.Models;
using Microsoft.EntityFrameworkCore;

namespace Agencia1.Data
{
    public class NovoUserContext : DbContext
    {
        public NovoUserContext(DbContextOptions<NovoUserContext> opt) : base(opt)
        {
        }
        public DbSet<NovoUser> NovoUsers { get; set; }
        public DbSet<Agencia1.Models.DestinoUser> DestinoUser { get; set; }
    }
}


