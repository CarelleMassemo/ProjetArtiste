using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetArtiste1.Models
{
    public class LigneCommande
    {
        [Key]
        public int Id { get; set; }

        public Oeuvre oeuvre { get; set; }

        public int quantite { get; set; }

        public string CommandeId { get; set; }

        
    }

    
}
