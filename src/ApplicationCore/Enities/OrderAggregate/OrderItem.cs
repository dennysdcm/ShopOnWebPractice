namespace ShopOnWeb.ApplicationCore.Enities.OrderAggregate
{
    public class OrderItem : BaseEntity
    {
        public CatalogItemOrdered ItemOrdered { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal Units { get; set; }

        private OrderItem()
        {
            // required by EF
        }

        public OrderItem(CatalogItemOrdered itemOrdered, decimal unitPrice, int units)
        {
            this.ItemOrdered = itemOrdered;
            this.UnitPrice = unitPrice;
            this.Units = units
        }
    }
}
