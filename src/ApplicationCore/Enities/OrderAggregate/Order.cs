using Ardalis.GuardClauses;
using ShopOnWeb.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;

namespace ShopOnWeb.ApplicationCore.Enities.OrderAggregate
{
    public class Order : BaseEntity, IAggregateRoot
    {
        // DDD pattern comment
        // Using private collection field, better for DDD Aggregate's encapsulation
        // so OrderItems cannot be added from "outside the AggregateRoot" directly to the collection
        // but only through the methos Order.AddOrderItem() which includes behavior.
        private readonly List<OrderItem> orderItems = new List<OrderItem>();

        public string BuyerId { get; private set; }
        public DateTimeOffset OrderDate { get; private set; } = DateTimeOffset.Now;
        public Address ShipToAddress { get; private set; }
        // Using AsReadOnly() will create a read only wrapper around the list so is protected agaist external updates
        // It is cheaper than .ToList() because it will not have to copy all items in a new collection.
        public IReadOnlyCollection<OrderItem> OrderItems => this.orderItems.AsReadOnly();

        private Order()
        {
            //required by EF
        }

        public Order(string buyerId, Address shipToAddress, List<OrderItem> items)
        {
            Guard.Against.NullOrEmpty(buyerId, nameof(buyerId));
            Guard.Against.Null(shipToAddress, nameof(shipToAddress));
            Guard.Against.Null(items, nameof(items));

            this.BuyerId = buyerId;
            this.ShipToAddress = shipToAddress;
            this.orderItems = items;
        }

        public decimal Total()
        {
            var total = 0m;
            foreach (var item in this.orderItems)
            {
                total += item.UnitPrice * item.Units;
            }

            return total;
        }

    }
}