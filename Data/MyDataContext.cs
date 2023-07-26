using Microsoft.EntityFrameworkCore;

namespace SinafApi.Models
{

    public class MyDataContext : DbContext
    {
        public MyDataContext(DbContextOptions<MyDataContext> options) : base(options) { }

        public DbSet<Pix>? Pixes { get; set; }
        public DbSet<Boleto>? Boletos { get; set; } 
        public DbSet<MeioPagamento>? MeioPagamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ClienteAvaliacao>().HasKey(k => new
            //{
            //    k.ClienteId,
            //    k.AvaliacaoId
            //});

            //modelBuilder.Entity<Pix>().HasIndex(c => c.Cnpj);

            //foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            //{
            //    relationship.DeleteBehavior = DeleteBehavior.Restrict;
            //}
        }
    }
}