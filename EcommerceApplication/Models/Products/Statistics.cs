using EcommerceApplication.Models.Users;
using System.ComponentModel.DataAnnotations;

namespace EcommerceApplication.Models.Products
{
    public class Statistics
    {
        [Key]
        public int StatisticsId { get; set; }
        public int Favorites { get; set; }
        public int SellCount { get; set; }
        public double ReviewScore { get; set; }
        public ICollection<Review>? Reviews { get; set; }

        // Parent reference
        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }

    }
}
