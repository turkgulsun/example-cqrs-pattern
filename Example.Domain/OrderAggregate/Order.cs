using Example.Domain.Core;

namespace Example.Domain.OrderAggregate;

public class Order : Entity, IAggregateRoot
{
    public DateTime CreatedDate { get; private set; }
    public string BuyerId { get; private set; }

    private readonly List<OrderItem> _orderItems;

    public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

    public Order()
    {
    }

    public Order(string buyerId)
    {
        _orderItems = new List<OrderItem>();
        CreatedDate = DateTime.UtcNow;
        BuyerId = buyerId;
    }

    public void AddOrderItem(string productId, string productName, decimal price)
    {
        var existProduct = _orderItems.Any(x => x.ProductId == productId);

        if (!existProduct)
        {
            var newOrderItem = new OrderItem(productId, productName, price);

            _orderItems.Add(newOrderItem);
        }
    }

    public decimal GetTotalPrice => _orderItems.Sum(x => x.Price);
}