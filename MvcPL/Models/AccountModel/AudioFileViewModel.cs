using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcPL.Models.AccountModel
{
    public class AudioFileViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required field SongName")]
        [Display(Name ="Song Name")]
        public string SongName { get; set; }
        [Required(ErrorMessage = "Required field Genre")]
        [Display(Name = "Genre")]
        public string Genre { get; set; }
        [Required(ErrorMessage = "Required field Rating")]
        [Display(Name = "Rating")]
        public int Rating { get; set; }
        [Required(ErrorMessage = "Required field Artist")]
        [Display(Name = "Artist")]
        public string Artist { get; set; }
        [Required(ErrorMessage = "Required field Body")]
        [Display(Name = "Body")]
        public HttpPostedFileBase Body { get; set; }
        
    }
}