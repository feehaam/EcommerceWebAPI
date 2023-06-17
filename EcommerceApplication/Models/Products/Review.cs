using EcommerceApplication.DTO.Products;
using EcommerceApplication.IRepository.Users;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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
        [JsonIgnore]
        public virtual Statistics? Statistics { get; set; }
    }
}
