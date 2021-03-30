using Ardalis.GuardClauses;

namespace ShopOnWeb.ApplicationCore.Enities.BasketAggregate
{
    public class BasketItem : BaseEntity
    {
        public decimal UnitPrice { get; private set; }
        public int Quantity { get; private set; }
        public int CatalogItemId { get; private set; }
        public int BasketId { get; private set; }

        public BasketItem(int catalogItemId, int quantity, decimal unitPrice)
        {
            this.CatalogItemId = catalogItemId;
            this.Quantity = quantity;
            this.UnitPrice = unitPrice;
        }

        public void AddQuantity(int quantity)
        {
            Guard.Against.OutOfRange(quantity, nameof(quantity), 0, int.MaxValue);

            this.Quantity += quantity;
        }

        public void SetQuantity(int quantity)
        {
            Guard.Against.OutOfRange(quantity, nameof(quantity), 0, int.MaxValue);

            this.Quantity = quantity;
        }
    }
}
