using System.ComponentModel.DataAnnotations;

namespace ProjetArtiste1.Models
{

    public class AmiArtiste
    {

        [Key]
        public int Id { get; set; }

        public string site{ get; set; }


    }
}
