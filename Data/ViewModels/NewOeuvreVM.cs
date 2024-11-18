using ProjetArtiste1.Data;
using ProjetArtiste1.Data.Base;
using ProjetArtiste1.Data.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetArtiste1.Models
{
    public class NewOeuvreVM
    {
        public int Id { get; set; }

        [Display(Name = " name Oeuvre ")]
        [Required(ErrorMessage = "Name is required")]
        public string nom { get; set; }

        [Display(Name = "Oeuvre description")]
        [Required(ErrorMessage = "Description is required")]
        public string description { get; set; }

        [Display(Name = "Prix in $")]
        [Required(ErrorMessage = "Price is required")]
        public double prix { get; set; }

        [Display(Name = "Oeuvre poster URL")]
        [Required(ErrorMessage = "Oeuvre poster URL is required")]
        public string imageURL { get; set; }


        [Display(Name = "Oeuvre date creation")]
        [Required(ErrorMessage = "Create date is required")]
        public DateTime dateCreation { get; set; }

        [Display(Name = "Select a category")]
        [Required(ErrorMessage = "Oeuvre category is required")]
        public OeuvreCategorie oeuvreCategorie { get; set; }

       

        //Relationships

    }
}
