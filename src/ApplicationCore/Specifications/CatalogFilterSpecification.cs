using Ardalis.Specification;
using ShopOnWeb.ApplicationCore.Enities;

namespace ShopOnWeb.ApplicationCore.Specifications
{
    public class CatalogFilterSpecification : Specification<CatalogItem>
    {
        public CatalogFilterSpecification(int? brandId, int? typeId)
        {
            this.Query
                .Where(i => (!brandId.HasValue || i.CatalogBrandId == brandId) && 
                    (!typeId.HasValue || i.CatalogTypeId == typeId));
        }
    }
}
