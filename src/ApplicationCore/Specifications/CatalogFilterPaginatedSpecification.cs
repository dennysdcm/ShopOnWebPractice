using Ardalis.Specification;
using ShopOnWeb.ApplicationCore.Enities;
using System.Linq;

namespace ShopOnWeb.ApplicationCore.Specifications
{
    public class CatalogFilterPaginatedSpecification : Specification<CatalogItem>
    {
        public CatalogFilterPaginatedSpecification(int skip, int take, int? brandId, int? typeId)
            : base()
        {
            this.Query
                .Where(i => (!brandId.HasValue || i.CatalogBrandId == brandId) &&
                    (!typeId.HasValue || i.CatalogTypeId == typeId))
                .Paginate(skip, take);
        }
    }
}
