using Ardalis.GuardClauses;
using ShopOnWeb.ApplicationCore.Interfaces;
using System.Collections.Generic;

namespace ShopOnWeb.ApplicationCore.Enities.BuyerAggregate
{
    public class Buyer : BaseEntity, IAggregateRoot
    {
        private List<PaymentMethod> paymentMethods = new List<PaymentMethod>();

        public string IdentityGuid { get; private set; }
        public IEnumerable<PaymentMethod> PaymentMethods => this.paymentMethods.AsReadOnly();

        private Buyer()
        {
            // required by EF
        }

        public Buyer(string identity) : this()
        {
            Guard.Against.NullOrEmpty(identity, nameof(identity));

            this.IdentityGuid = identity;
        }


    }
}
