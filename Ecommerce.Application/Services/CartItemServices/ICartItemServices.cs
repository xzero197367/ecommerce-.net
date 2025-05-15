using Ecommerce.Application.Services.GenericServices;
using Ecommerce.DTOs;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Services.CartItemServices
{
    public interface ICartItemServices: IGenericService<CartItemDto, CartItemCreateDto, CartItem>
    {

    }
}
