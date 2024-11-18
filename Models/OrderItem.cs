using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetArtiste1.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        public int quantite { get; set; }
        public double prix { get; set; }

        public int OeuvreId { get; set; }
        [ForeignKey("OeuvreId")]
        public Oeuvre Oeuvre { get; set; }

        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
    }
}

