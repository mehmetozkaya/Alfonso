using ApplicationCore.Interfaces;

namespace ApplicationCore.Services
{
    public class UriComposer : IUriComposer
    {
        private readonly CatalogSettings _catalogSettings;

        public UriComposer(CatalogSettings catalogSettings) => _catalogSettings = catalogSettings;

        public string ComposePicUri(string uriTemplate)
        {
            // TODO Fix : bunu yazmayınca image degisik geliyor
            if (!uriTemplate.Contains("/assets/images/product/"))
            {
                return "/assets/images/product/" + uriTemplate;
            }

            return uriTemplate;
            // return uriTemplate.Replace("http://catalogbaseurltobereplaced", _catalogSettings.CatalogBaseUrl);
        }
    }
}
