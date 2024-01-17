using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Party.Models
{
    public class Guest
    {
        [Required(ErrorMessage = "Sissesta nimi siia")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Sissesta eaadress siia")]
        [RegularExpression(@".+\@.+\..+", ErrorMessage = "Vale eaadress")]
        public string Email { get; set; }
        [RegularExpression(@"\+372[0-9]{8}", ErrorMessage = "Vale number")]//?
        public string Phone { get; set; }
        [Required(ErrorMessage = "Tee oma valik")]
        public bool? WillAttend { get; set; }

        public string Notes { get; set; }
    }



}