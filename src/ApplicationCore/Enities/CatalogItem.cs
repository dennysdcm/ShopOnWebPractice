using Ardalis.GuardClauses;
using ShopOnWeb.ApplicationCore.Interfaces;
using System;

namespace ShopOnWeb.ApplicationCore.Enities
{
    public class CatalogItem : BaseEntity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public string PictureUri { get; private set; }
        public int CatalogTypeId { get; private set; }
        public CatalogType CatalogType { get; private set; }
        public int CatalogBrandId { get; private set; }
        public CatalogBrand CatalogBrand { get; private set; }

        public CatalogItem(
            int catalogTypeId,
            int catalogBrandId,
            string description,
            string name,
            decimal price,
            string pictureUri)
        {
            this.CatalogTypeId = catalogTypeId;
            this.CatalogBrandId = catalogBrandId;
            this.Description = description;
            this.Name = name;
            this.Price = price;
            this.PictureUri = pictureUri;
        }

        public void UpdateDetails(string name, string description, decimal price)
        {
            Guard.Against.NullOrEmpty(name, nameof(name));
            Guard.Against.NullOrEmpty(description, nameof(description));
            Guard.Against.NegativeOrZero(price, nameof(price));

            this.Name = name;
            this.Description = description;
            this.Price = price;
        }

        public void UpdateBrand(int catalogBrandId)
        {
            Guard.Against.Zero(catalogBrandId, nameof(catalogBrandId));

            this.CatalogBrandId = catalogBrandId;
        }

        public void UpdateType(int catalogTypeId)
        {
            Guard.Against.Zero(catalogTypeId, nameof(catalogTypeId));

            this.CatalogTypeId = catalogTypeId;
        }

        public void UpdatePictureUri(string pictureName)
        {
            if (string.IsNullOrEmpty(pictureName))
            {
                this.PictureUri = string.Empty;
                return;
            }

            this.PictureUri = $"images\\products\\{pictureName}?{new DateTime().Ticks}";
        }
    }
}
