using MvcPL.Infrastructure.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcPL.Models
{
    [NotNullOrEmptyPropertyString(ErrorMessage = "Fill in at least one field")]
    public class SearchModel
    {
        [Display(Name = "Song Name")]
        public string SongName { get; set; }
        [Display(Name = "Genre")]
        public string Genre { get; set; }
        [Display(Name = "Artist")]
        public string Artist { get; set; }
    }
}