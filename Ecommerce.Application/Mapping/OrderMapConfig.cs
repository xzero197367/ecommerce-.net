﻿

using Ecommerce.DTOs;
using Ecommerce.Models;
using Mapster;

namespace Ecommerce.Application.Mapping
{
    public class OrderMapConfig
    {
        public static void Config()
        {

            // Mapping from OrderDto → Order (Entity)
            TypeAdapterConfig<OrderDto, Order>.NewConfig()
                .Map(dest => dest.OrderID, src => src.OrderID)
                .Map(dest => dest.UserID, src => src.UserID)
                .Map(dest => dest.OrderDate, src => src.OrderDate)
                .Map(dest => dest.TotalAmount, src => src.TotalAmount)
                .Map(dest => dest.Status, src => src.Status)
                .Map(dest => dest.DateProcessed, src => src.DateProcessed)
                //.Map(dest => dest.User, src => src.User != null ? src.User.Adapt<User>() : null)
                .Map(dest => dest.Details, src => src.Details != null
                    ? src.Details.Adapt<List<OrderDetail>>()
                    : new List<OrderDetail>())
                .IgnoreNullValues(true);

            TypeAdapterConfig<Order, OrderDto>.NewConfig()
             .Map(dest => dest.OrderID, src => src.OrderID)
             .Map(dest => dest.UserID, src => src.UserID)
             .Map(dest => dest.OrderDate, src => src.OrderDate)
             .Map(dest => dest.TotalAmount, src => src.TotalAmount)
             .Map(dest => dest.Status, src => src.Status)
             .Map(dest => dest.DateProcessed, src => src.DateProcessed)
             //.Map(dest => dest.User, src => src.User != null ? src.User.Adapt<UserDto>() : null)
             .Map(dest => dest.Details, src => src.Details != null
                 ? src.Details.Adapt<List<OrderDetailDto>>()
                 : new List<OrderDetailDto>());
             //.IgnoreNullValues(true);

        }
    }
}
