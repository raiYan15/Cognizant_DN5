namespace EFCore.CrudLinq.DTOs
{
    // A projection target so we don't leak full entities (and don't pull unneeded columns from the DB).
    public class ProductSummaryDto
    {
        public string ProductName { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
