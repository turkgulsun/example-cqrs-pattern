namespace Example.Application.DTOs;

public class OrderItemDto
{
    public required string ProductId { get; set; }
    public required string ProductName { get; set; }
    public Decimal Price { get; set; }
}