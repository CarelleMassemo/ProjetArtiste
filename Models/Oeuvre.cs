using ProjetArtiste1.Data.Base;
using ProjetArtiste1.Data.Enum;
using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProjetArtiste1.Data.Base;

namespace ProjetArtiste1.Models
{
    public class Oeuvre: IEntityBase
    {
        [Key]
        public int Id { get; set; }

        public string nom { get; set; }
         public string description { get; set; }

        public double prix { get; set; }

        public string imageURL { get; set; }

        public DateTime dateCreation { get; set; }
        
        public OeuvreCategorie oeuvreCategorie{ get; set; }

    }
}
