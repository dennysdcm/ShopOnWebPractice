using Ardalis.Specification;
using ShopOnWeb.ApplicationCore.Enities.BasketAggregate;
using System.Linq;

namespace ShopOnWeb.ApplicationCore.Specifications
{
    public class BasketWithItemsSpecification : Specification<Basket>
    {
        public BasketWithItemsSpecification(int basketId)
        {
            this.Query
                .Where(b => b.Id == basketId)
                .Include(b => b.Items);
        }

        public BasketWithItemsSpecification(string buyerId)
        {
            this.Query
                .Where(b => b.BuyerId == buyerId)
                .Include(b => b.Items);
        }        
    }
}
