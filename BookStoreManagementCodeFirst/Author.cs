using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagementCodeFirst
{
   public class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AuthorId { get; set; }
        [Required]
        [StringLength(50)]
        public string AuthorName { get; set; }
        [Required]
        [StringLength(50)]
   

        public string History { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
