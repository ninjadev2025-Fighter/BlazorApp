using Microsoft.AspNetCore.Components;
using NinjaDev.Domain;
using NinjaDev.Domain.Interfaces;
using NinjaDev.Services;

namespace NinjaDev.Components.Pages
{
    public partial class Productpage
    {

        #region properties
        private List<Product> Products = new();
        IProductRepository ProductService;
        #endregion

        #region parameters
        [Parameter]
        public string CatId { get; set; }
        [Parameter]
        public string CatName { get; set; }
        #endregion

        #region ctor
        public Productpage( IProductRepository _productService)
        {
            ProductService = _productService;
        }
        #endregion

        #region lifecycle
        protected override void OnInitialized()
        {
            base.OnInitialized();
            Products = ProductService.GetByCategory(int.Parse(CatId));
        }
        #endregion


    }
}
