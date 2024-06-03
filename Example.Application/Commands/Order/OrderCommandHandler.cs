using Example.Application.DTOs;
using Example.Infrastructure;
using Example.Shared.BaseDTOs;
using MediatR;

namespace Example.Application.Commands.Order;

public class OrderCommandHandler(OrderDbContext orderDbContext): IRequestHandler<OrderCreateCommand, BaseResult<CreatedOrderDto>>
{
    public async Task<BaseResult<CreatedOrderDto>> Handle(OrderCreateCommand request, CancellationToken cancellationToken)
    {
        
        Domain.OrderAggregate.Order newOrder = new Domain.OrderAggregate.Order(request.BuyerId);

        request.OrderItems.ForEach(x =>
        {
            newOrder.AddOrderItem(x.ProductId, x.ProductName, x.Price);
        });

        await orderDbContext.Orders.AddAsync(newOrder);

        await orderDbContext.SaveChangesAsync();

        return BaseResult<CreatedOrderDto>.Success(new CreatedOrderDto { OrderId = newOrder.Id }, 200);
    }
}