using System.ComponentModel.DataAnnotations;

namespace EcommerceApplication.Models.Products
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public float Rating { get; set; }
        public string? Comment { get; set; }
        public int UpVote { get; set; }
        public int DownVote { get; set; }

        // Parent reference
        public int StatisticsId { get; set; }
        public virtual Statistics? Statistics { get; set; }
    }
}
