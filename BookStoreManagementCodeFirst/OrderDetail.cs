using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagementCodeFirst
{
    public class OrderDetail
    {

        [Key]
        [Column(Order = 1)]
        public int OrderID { get; set; }
        [Key]
        [Column(Order = 2)]
        public int BookID { get; set; }
        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }
        public int Discount { get; set; }

        [ForeignKey("BookID")]
        public virtual Book Book { get; set; }

        [ForeignKey("OrderID")]
        public virtual Order Order { get; set; }
    }
}
