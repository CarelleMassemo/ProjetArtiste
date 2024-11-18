 using Microsoft.EntityFrameworkCore;
using ProjetArtiste1.Models;
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;



namespace ProjetArtiste1.Data.Cart
{
    public class Commande
    {
        public ApplicationDbContext _context {get;set;}

        public string CommandeId { get;set;} 
        
        public List<LigneCommande> LigneCommandes { get; set;}
        public Commande (ApplicationDbContext context)
        {
            _context = context;
           
        }
        public static Commande GetShoppingCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<ApplicationDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new Commande(context) { CommandeId = cartId };
        }

        public void AddItemToCart(Oeuvre Oeuvre)
        {
            var LigneCommande = _context.LigneCommandes.FirstOrDefault(n => n.oeuvre.Id == Oeuvre.Id && n.CommandeId == CommandeId);

            if (LigneCommande == null)
            {
                LigneCommande = new LigneCommande()
                {
                    CommandeId = CommandeId,
                    oeuvre = Oeuvre,
                    quantite = 1
                };

                _context.LigneCommandes.Add(LigneCommande);
            }
            else
            {
                LigneCommande.quantite++;
            }
            _context.SaveChanges();
        }

        public void RemoveItemFromCart(Oeuvre Oeuvre)
        {
            var LigneCommande = _context.LigneCommandes.FirstOrDefault(n => n.oeuvre.Id == Oeuvre.Id && n.CommandeId == CommandeId);

            if (LigneCommande != null)
            {
                if (LigneCommande.quantite > 1)
                {
                    LigneCommande.quantite--;
                }
                else
                {
                    _context.LigneCommandes.Remove(LigneCommande);
                }
            }
            _context.SaveChanges();
        }

        public List<LigneCommande> GetShoppingCartItems()
        {
            return LigneCommandes ?? (LigneCommandes = _context.LigneCommandes.Where(n => n.CommandeId == CommandeId).Include(n => n.oeuvre).ToList());
        }

        public double GetShoppingCartTotal() => _context.LigneCommandes.Where(n => n.CommandeId == CommandeId).Select(n => n.oeuvre.prix * n.quantite).Sum();

        public async Task ClearShoppingCartAsync()
        {
            var items = await _context.LigneCommandes.Where(n => n.CommandeId == CommandeId).ToListAsync();
            _context.LigneCommandes.RemoveRange(items);
            await _context.SaveChangesAsync();
        }

        
    }



}


