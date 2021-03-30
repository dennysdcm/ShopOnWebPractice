namespace ShopOnWeb.ApplicationCore.Enities.OrderAggregate
{
    public class Address // ValueObject
    {
        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }

        private Address()
        {
        }

        public Address(string street, string city, string state, string country, string zipCode)
        {
            this.Street = street;
            this.City = city;
            this.State = state;
            this.Country = country;
            this.ZipCode = zipCode;
        }
    }
}
