using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ProjetArtiste1.Models
{
    public class ApplicationUser : IdentityUser
    {
        // relation 1 a plusieurs un utilisateur peut ecrire plusieur message

        [Display(Name = "Full name")]
        public string FullName { get; set; }
        public ApplicationUser()
        {

            Messages = new HashSet<Message> ();

         }
        public virtual ICollection<Message> Messages {  get; set; }

    }
}
