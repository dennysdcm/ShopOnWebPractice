using ShopOnWeb.ApplicationCore.Enities.BasketAggregate;
using ShopOnWeb.ApplicationCore.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace Ardalis.GuardClauses
{
    public static class BasketGuardExtensions
    {
        public static void NullBasket(this IGuardClause guardClause, int basketId, Basket basket)
        {
            if (basket == null)
            {
                throw new BasketNotFoundException(basketId);
            }
        }

        public static void EmptyBasketOnCheckout(this IGuardClause guard, IReadOnlyCollection<BasketItem> basketItems)
        {
            if (!basketItems.Any())
            {
                throw new EmptyBasketOnCheckoutException();
            }
        }
    }
}
