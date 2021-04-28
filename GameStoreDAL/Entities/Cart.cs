using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStoreDAL.Entities
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public int? GameId { get; set; }
        public int Quantity { get; set; }
        public virtual Game Game { get; set; }
    }
}
