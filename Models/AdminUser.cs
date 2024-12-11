using System.ComponentModel.DataAnnotations;

namespace bookstore.Models
{
    public class AdminUser
    {
        public int AdminUserId { get; set; }
        [Required]
        [StringLength(50)]
        public string Username { get; set; }
        [Required]
        [StringLength(255)]
        public string PasswordHash { get; set; }
        [Required]
        [StringLength(50)]
        public string Role { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime LastLogin { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime UpdatedAt { get; set; }
    }
}
