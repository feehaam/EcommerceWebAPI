using System.ComponentModel.DataAnnotations;

namespace EcommerceApplication.Models.Users
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }
        public string Country { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string StreetHomeOther { get; set; } = string.Empty;
    }
}
