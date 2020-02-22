using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagementCodeFirst
{
   public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentId { get; set; }
        [Required]
        public int BookId { get; set; }

        public string UserName { get; set; }
        [StringLength(1000)]
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual Book Book { get; set; }

        public virtual Users User { get; set; }
    }
}
