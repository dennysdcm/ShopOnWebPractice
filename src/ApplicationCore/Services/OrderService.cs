using Ardalis.GuardClauses;
using ShopOnWeb.ApplicationCore.Enities;
using ShopOnWeb.ApplicationCore.Enities.BasketAggregate;
using ShopOnWeb.ApplicationCore.Enities.OrderAggregate;
using ShopOnWeb.ApplicationCore.Interfaces;
using ShopOnWeb.ApplicationCore.Specifications;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnWeb.ApplicationCore.Services
{
    public class OrderService : IOrderService
    {
        private readonly IAsyncRepository<Basket> basketRepository;
        private readonly IAsyncRepository<CatalogItem> itemRepository;
        private readonly IAsyncRepository<Order> orderRepository;
        private readonly IUriComposer uriComposer;

        public OrderService(
            IAsyncRepository<Basket> basketRepository, 
            IAsyncRepository<CatalogItem> itemRepository,
            IAsyncRepository<Order> orderRepository, 
            IUriComposer uriComposer) 
        {
            this.basketRepository = basketRepository;
            this.itemRepository = itemRepository;
            this.orderRepository = orderRepository;
            this.uriComposer = uriComposer;
        }

        public async Task CreateOrderAsync(int basketId, Address shippingAddress)
        {
            var basketSpec = new BasketWithItemsSpecification(basketId);
            var basket = await this.basketRepository.FirstOrDefaultAsync(basketSpec);

            Guard.Against.NullBasket(basketId, basket);
            Guard.Against.EmptyBasketOnCheckout(basket.Items);

            var catalogItemsSpecification = new CatalogItemsSpecification(basket.Items.Select(item => item.CatalogItemId).ToArray());
            var catalogItems = await this.itemRepository.ListAsync(catalogItemsSpecification);

            var items = basket.Items.Select(basketItem =>
            {
                var catalogItem = catalogItems.First(c => c.Id == basketItem.CatalogItemId);
                var itemOrdered = new CatalogItemOrdered(catalogItem.Id, catalogItem.Name, this.uriComposer.ComposePicUri(catalogItem.PictureUri));
                var orderItem = new OrderItem(itemOrdered, basketItem.UnitPrice, basketItem.Quantity);

                return orderItem;
            }).ToList();

            var order = new Order(basket.BuyerId, shippingAddress, items);

            await this.orderRepository.AddAsync(order);
        }
    }
}