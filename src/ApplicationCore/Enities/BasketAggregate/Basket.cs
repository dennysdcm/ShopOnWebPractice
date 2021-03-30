using ShopOnWeb.ApplicationCore.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ShopOnWeb.ApplicationCore.Enities.BasketAggregate
{
    public class Basket : BaseEntity, IAggregateRoot
    {
        private readonly List<BasketItem> items = new List<BasketItem>();

        public string BuyerId { get; private set; }
        public IReadOnlyCollection<BasketItem> Items => this.items.AsReadOnly();

        public Basket(string buyerId)
        {
            this.BuyerId = buyerId;
        }

        public void AddItem(int catalogItemId, decimal unitPrice, int quantity = 1)
        {
            if (!this.Items.Any(i => i.CatalogItemId == catalogItemId))
            {
                this.items.Add(new BasketItem(catalogItemId, quantity, unitPrice));
            }

            var existingItem = Items.FirstOrDefault(i => i.CatalogItemId == catalogItemId);
            existingItem.AddQuantity(quantity);
        }

        public void RemoveEmptyItems()
        {
            items.RemoveAll(i => i.Quantity == 0);
        }

        public void SetNewBuyerId(string buyerId)
        {
            this.BuyerId = buyerId;
        }
    }
}
