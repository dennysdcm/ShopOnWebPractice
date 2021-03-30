using ShopOnWeb.ApplicationCore.Interfaces;

namespace ShopOnWeb.ApplicationCore.Services
{
    public class UriCompser : IUriComposer
    {
        private readonly CatalogSettings catalogSettings;

        public UriCompser(CatalogSettings catalogSettings)
        {
            this.catalogSettings = catalogSettings;
        }

        public string ComposePicUri(string uriTemplate)
        {
            return uriTemplate.Replace("http://catalogbaseurltobereplaced", catalogSettings.CatalogBaseUrl);
        }
    }
}