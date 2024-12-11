using System.ComponentModel.DataAnnotations;

namespace bookstore.Models
{
    public class Review
    {
        public int ReviewId { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }
        [Required]
        [StringLength(1000)]
        public string ReviewText { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReviewDate { get; set; }
    }
}
