using ShopOnWeb.ApplicationCore.Interfaces;

namespace ShopOnWeb.ApplicationCore.Enities
{
    public class CatalogType : BaseEntity, IAggregateRoot
    {
        public string Type { get; private set; }

        public CatalogType(string type)
        {
            this.Type = type;
        }
    }
}
