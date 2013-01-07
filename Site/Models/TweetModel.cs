using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Site.Models
{
    public class TweetModel
    {
        public int Id { get; set; }

        [Display(Name = "Bericht")]
        [Required(ErrorMessage = "{0} is verplicht")]
        public string Message { get; set; }

        [Display(Name = "Gebruikersnaam")]
        [Required(ErrorMessage = "{0} is verplicht")]
        [MinLength(3, ErrorMessage = "{0} is te kort")]
        public string User { get; set; }

        [Display(Name = "Plaatsdatum")]
        public DateTime Date { get; set; }
    }
}
