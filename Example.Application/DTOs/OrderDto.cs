namespace Example.Application.DTOs;

public class OrderDto
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public required string BuyerId { get; set; }
    public required List<OrderItemDto> OrderItems { get; set; }
}