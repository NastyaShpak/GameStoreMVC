using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameStore.Client.Models
{
    public class GenreViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Введіть, будь ласка, назву жанру")]
        [MinLength(2)]
        public string Name { get; set; }
    }
}