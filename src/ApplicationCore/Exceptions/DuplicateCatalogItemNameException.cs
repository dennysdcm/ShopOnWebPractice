using System;

namespace ShopOnWeb.ApplicationCore.Exceptions
{
    public class DuplicateCatalogItemNameException : Exception
    {
        public DuplicateCatalogItemNameException(string message, int duplicatedItemId) : base(message)
        {
            this.DuplicatedItemId = duplicatedItemId;
        }

        public int DuplicatedItemId { get; }
    }
}
