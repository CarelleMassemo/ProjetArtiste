using ProjetArtiste1.Data.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetArtiste1.Data.ViewModels
{
    public class CommandeVM
    {
        public Commande commande { get; set; }
        public double ShoppingCartTotal { get; set; }
    }
}
