﻿using System;
using System.Runtime.Serialization;

namespace ShopOnWeb.ApplicationCore.Exceptions
{
    public class BasketNotFoundException : Exception
    {
        public BasketNotFoundException(int basketId)
            : base($"No basket found with id {basketId}")
        {
        }

        public BasketNotFoundException(string message)
            : base(message)
        {
        }

        public BasketNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected BasketNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
