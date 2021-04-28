using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameStore.Client.Models
{
    public class GameViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Введіть, будь ласка, назву ігри")]
        [MinLength(2)]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Введіть, будь ласка, ціну")]
        [Range(1, 200, ErrorMessage="Ціна не повинна бути більша за 200 та менша за 1")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Введіть, будь ласка, рік")]
        [Range(1980, 2020)]
        public int Year { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Виберіть, будь ласка, із списку")]
        public string Genre { get; set; }
        public string Developer { get; set; }
        [Range(1, 500)]
        public int Quantity { get; set; }
    }
}