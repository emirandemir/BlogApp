using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BlogApp.Data
{
    [Index(nameof(SecoUrl),IsUnique = true)]
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(250)]
        [Required]
        public string Definition { get; set; } = null!;

        [MaxLength(300)]
        [Required]
        public string SecoUrl { get; set; } = null!;
        public List<BlogCategory>? BlogCategories { get; set; }
    }
    
}
