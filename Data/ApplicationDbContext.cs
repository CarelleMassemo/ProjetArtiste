using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjetArtiste1.Models;

namespace ProjetArtiste1.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder buider)
        {
            base.OnModelCreating(buider);
            
         /*   buider.Entity<Message>()
                .HasOne<ApplicationUser>(a => a.Sender) //l'entité Message a une relation avec un seul AppUser
                .WithMany(d => d.Messages) //  l'entité AppUser peut avoir plusieurs Messages
                .HasForeignKey( d => d.UserID); // la colonne UserID dans la table des messages sera utilisée 
          */                                      // pour stocker la clé étrangère qui fait référence à l'entité AppUser

        }
         public DbSet<Message> Messages { get; set; }
        public DbSet<Oeuvre> Oeuvres { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<LigneCommande> LigneCommandes { get; set; }
        
    }
}
