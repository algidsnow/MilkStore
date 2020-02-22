using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagementCodeFirst
{
  public  class Users
    {
        [Key]
        [StringLength(50)]
        public string UserName { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(10)]
        public string Role { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
