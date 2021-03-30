using Ardalis.Specification;
using ShopOnWeb.ApplicationCore.Enities.OrderAggregate;

namespace ShopOnWeb.ApplicationCore.Specifications
{
    public class CustomerOrdersWithItemsSpecification : Specification<Order>
    {
        public CustomerOrdersWithItemsSpecification(string buyerId)
        {
            this.Query.Where(o => o.BuyerId == buyerId)
                .Include(o => o.OrderItems)
                .ThenInclude(i => i.ItemOrdered);
        }
    }
}
