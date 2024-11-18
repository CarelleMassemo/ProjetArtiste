using System.ComponentModel.DataAnnotations;

namespace ProjetArtiste1.Models
{
    public class Message
    {
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string text { get; set; }

        public DateTime date{ get; set; }

        public string UserID { get; set; } 

      //  public virtual ApplicationUser  Sender { get; set; }    


    }
}
