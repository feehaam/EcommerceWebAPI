namespace EcommerceApplication.DTO.Orders
{
    public class ReadOrderItemDto 
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public Photos ? Photos { get; set; }
    }
    public class Photos
    {
        public string URL1 { get; set; } = string.Empty;
        public string URL2 { get; set; } = string.Empty;
        public string URL3 { get; set; } = string.Empty;
        public Photos(string u1, string u2, string u3)
        {
            URL1 = u1;
            URL2 = u2;
            URL3 = u3;
        }
    }
}
