using System.ComponentModel.DataAnnotations;

namespace EcommerceApplication.Models.Users
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        public string Primary { get; set; } = string.Empty;
        public string Optional1 { get; set; } = string.Empty;
        public string Optional2 { get; set; } = string.Empty;

        // Parent reference
        public int UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
