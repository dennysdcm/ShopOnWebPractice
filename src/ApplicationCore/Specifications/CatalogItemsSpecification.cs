using Ardalis.Specification;
using ShopOnWeb.ApplicationCore.Enities;
using System.Linq;

namespace ShopOnWeb.ApplicationCore.Specifications
{
    public class CatalogItemsSpecification : Specification<CatalogItem>
    {
        public CatalogItemsSpecification(params int[] ids)
        {
            this.Query
                .Where(c => ids.Contains(c.Id));
        }
    }
}
