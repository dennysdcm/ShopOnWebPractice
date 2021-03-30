using Ardalis.GuardClauses;

namespace ShopOnWeb.ApplicationCore.Enities.OrderAggregate
{
    /// <summary>
    /// Represents a snapshot of the item that was ordered. If catalog item detail change, details of
    /// item that was part of a completed order shoul no change
    /// </summary>
    public class CatalogItemOrdered // ValueObject
    {
        public int CatalogItemId { get; private set; }
        public string ProductName { get; private set; }
        public string PictureUri { get; private set; }

        private CatalogItemOrdered()
        {
            // required by EF
        }

        public CatalogItemOrdered(int catalogItemId, string productName, string pictureUri)
        {
            Guard.Against.OutOfRange(catalogItemId, nameof(catalogItemId), 1, int.MaxValue);
            Guard.Against.NullOrEmpty(productName, nameof(productName));
            Guard.Against.NullOrEmpty(pictureUri, nameof(pictureUri));

            this.CatalogItemId = catalogItemId;
            this.ProductName = productName;
            this.PictureUri = pictureUri;
        }
    }
}