using System.ComponentModel.DataAnnotations;

namespace bookstore.Models
{
    public class Book
    {
        public int BookId { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        public int Pages { get; set; }

        public string Description { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
