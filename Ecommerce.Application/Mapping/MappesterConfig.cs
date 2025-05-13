

namespace Ecommerce.Application.Mapping
{
    public class MappesterConfig
    {
        public static void Congfigure()
        {
          
            UserMapConfig.Config();
            CartItemMapConfig.Config();
            CategoryMapConfig.Config();
            OrderMapConfig.Config();
            OrderDetailsMapConfig.Config();
            ProductMapConfig.Config();
      
        }
    }
}
