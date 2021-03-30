using ShopOnWeb.ApplicationCore.Enities.OrderAggregate;
using System.Threading.Tasks;

namespace ShopOnWeb.ApplicationCore.Interfaces
{
    public interface IOrderService
    {
        Task CreateOrderAsync(int basketId, Address shippingAddress);
    }
}
