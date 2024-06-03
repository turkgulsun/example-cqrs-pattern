using Example.Application.DTOs;
using Example.Shared.BaseDTOs;
using MediatR;

namespace Example.Application.Commands.Order;

public class OrderCreateCommand: IRequest<BaseResult<CreatedOrderDto>>
{
    public required string BuyerId { get; set; }

    public required List<OrderItemDto> OrderItems { get; set; }
}