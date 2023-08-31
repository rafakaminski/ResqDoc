using Microsoft.EntityFrameworkCore;
using resqdoc2.Models.ResqDoc.Models;

namespace resqdoc2.Models
{
    public class Context : DbContext
    {

        public Context(DbContextOptions<Context> options)
            : base(options)
        { }

        public DbSet<Ocorrencia> Ocorrencia { get; set; }
    }
}
