using ShopOnWeb.ApplicationCore.Interfaces;

namespace ShopOnWeb.ApplicationCore.Enities
{
    public class CatalogBrand : BaseEntity, IAggregateRoot
    {
        public string Brand { get; private set; }

        public CatalogBrand(string brand)
        {
            this.Brand = brand;
        }
    }
}
