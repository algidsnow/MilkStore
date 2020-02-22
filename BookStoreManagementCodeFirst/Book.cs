using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagementCodeFirst
{
    [MetadataType(typeof(Book))]

    public class Book
    {
       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }
        [Required]
        [StringLength(50)]
        public string BookName { get; set; }
        [Required]
        public int CateId { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public int PubId { get; set; }

        
        [StringLength(1000000)]
        [AllowHtml]
        public string Summary { get; set; }
        [StringLength(100)]
        public string ImgUrl { get; set; }
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual Author Author { get; set; }
        public virtual Category Category { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual List<Comment> Comments { get; set; }
    }
}
