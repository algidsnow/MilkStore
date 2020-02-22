using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagementCodeFirst
{
   public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CateId { get; set; }
        [Required]
        [StringLength(50)]
        public string CateName { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
