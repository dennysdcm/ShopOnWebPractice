using System;
using System.Runtime.Serialization;

namespace ShopOnWeb.ApplicationCore.Exceptions
{
    public class EmptyBasketOnCheckoutException : Exception
    {
        public EmptyBasketOnCheckoutException()
            : base("Basket cannot have 0 ites on checkout")
        {
        }

        public EmptyBasketOnCheckoutException(string message)
            : base(message)
        {
        }

        public EmptyBasketOnCheckoutException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected EmptyBasketOnCheckoutException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
