using ShopOnWeb.ApplicationCore.Enities.OrderAggregate;
using System.Threading.Tasks;

namespace ShopOnWeb.ApplicationCore.Interfaces
{
    public interface IOrderRepository : IAsyncRepository<Order>
    {
        Task<Order> GetByIdWithItemsAsync(int id);
    }
}
