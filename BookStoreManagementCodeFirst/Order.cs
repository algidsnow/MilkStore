using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagementCodeFirst
{
   public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        [Required]
        [StringLength(50)]
        public string Username { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        [Required]
        [StringLength(100)]
        public string ShipAddress { get; set; }
        [Required]
        [StringLength(100)]
        public string ShipCity { get; set; }
        [Required]
        [StringLength(100)]
        public string ShipRegion { get; set; }
        [Required]
        [StringLength(100)]
        public string ShipPostalCode { get; set; }
        [Required]
        [StringLength(100)]

        public string ShipCountry { get; set; }

        public virtual Users User { get; set; }
      
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
