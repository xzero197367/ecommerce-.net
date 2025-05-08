using Ecommerce.DTOs;
using Ecommerce.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Mapping
{
    public class MappesterConfig
    {
        public static void Congfigure()
        {
          
            UserMapConfig.Config();

      
        }
    }
}
