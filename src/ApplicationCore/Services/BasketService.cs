using Ardalis.GuardClauses;
using ShopOnWeb.ApplicationCore.Enities.BasketAggregate;
using ShopOnWeb.ApplicationCore.Interfaces;
using ShopOnWeb.ApplicationCore.Specifications;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopOnWeb.ApplicationCore.Services
{
    public class BasketService : IBasketService
    {
        private readonly IAsyncRepository<Basket> basketRepository;
        private readonly IAppLogger<BasketService> logger;

        public BasketService(IAsyncRepository<Basket> basketRepository, IAppLogger<BasketService> logger)
        {
            this.basketRepository = basketRepository;
            this.logger = logger;
        }

        public async Task AddItemToBasket(int basketId, int catalogItemId, decimal price, int quantity = 1)
        {
            var basketSpec = new BasketWithItemsSpecification(basketId);
            var basket = await this.basketRepository.FirstOrDefaultAsync(basketSpec);
            Guard.Against.NullBasket(basketId, basket);

            basket.AddItem(catalogItemId, price, quantity);

            await this.basketRepository.UpdateAsync(basket);
        }

        public async Task DeleteBasketAsync(int basketId)
        {
            var basket = await this.basketRepository.GetByIdAsync(basketId);

            await this.basketRepository.DeleteAsync(basket);
        }

        public async Task SetQuantities(int basketId, Dictionary<string, int> quantities)
        {
            Guard.Against.Null(quantities, nameof(quantities));

            var basketSpec = new BasketWithItemsSpecification(basketId);
            var basket = await this.basketRepository.FirstOrDefaultAsync(basketSpec);
            Guard.Against.NullBasket(basketId, basket);

            foreach (var item in basket.Items)
            {
                if(quantities.TryGetValue(item.Id.ToString(), out var quantity))
                {
                    logger?.LogInformation($"Updading quantity of item ID: {item.Id} to {quantity}.");
                    item.SetQuantity(quantity);
                }
            }

            basket.RemoveEmptyItems();
            await this.basketRepository.UpdateAsync(basket);
        }

        public async Task TransferBasketAsync(string anonynousId, string userName)
        {
            Guard.Against.NullOrEmpty(anonynousId, nameof(anonynousId));
            Guard.Against.NullOrEmpty(userName, nameof(userName));

            var anonymousBasketSpec = new BasketWithItemsSpecification(anonynousId);
            var anonymousBasket = await this.basketRepository.FirstOrDefaultAsync(anonymousBasketSpec);
            if (anonymousBasket == null) return;

            var userBasketSpec = new BasketWithItemsSpecification(userName);
            var userBasket = await this.basketRepository.FirstOrDefaultAsync(userBasketSpec);
            if(userBasket == null)
            {
                userBasket = new Basket(userName);
                await basketRepository.AddAsync(userBasket);
            }

            foreach (var item in anonymousBasket.Items)
            {
                userBasket.AddItem(item.CatalogItemId, item.UnitPrice, item.Quantity);
            }

            await this.basketRepository.UpdateAsync(userBasket);
            await this.basketRepository.DeleteAsync(anonymousBasket);
        }
    }
}