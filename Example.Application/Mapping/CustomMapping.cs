using AutoMapper;
using Example.Application.DTOs;
using Example.Domain.OrderAggregate;

namespace Example.Application.Mapping;

internal class CustomMapping : Profile
{
    public CustomMapping()
    {
        CreateMap<Order, OrderDto>().ReverseMap();
        CreateMap<OrderItem, OrderItemDto>().ReverseMap();
    }
}