using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using NinjaDev.Data.Context;
using NinjaDev.Domain;
using NinjaDev.Domain.Interfaces;
using NinjaDev.Services;
using System.Threading.Tasks;

namespace NinjaDev.Components.Pages
{
    public partial class Home
    {
        //fields
        #region properties
        //initializing lists
        private List<Category> Categories = new();
        private List<Product> Products = new();


        // repository services
        ICategoryRepository _categoryService;
        IProductRepository _productService;


        //initializing models
        public Category NewCategory { get; set; } = new();
        public Category FilterCategory{ get; set; } = new();


        // initializing states
        private bool isEditMode { get; set; } = false;
        #endregion

        // constructor
        #region constructor
        public Home(ICategoryRepository categoryService, IProductRepository productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }
        #endregion

        // lifecycle
        #region lifecycle
        override protected void OnInitialized()
        {
            Categories = _categoryService.GetAll();
            Products = _productService.GetAll();
        }
        #endregion

        // events
        #region events
        void SaveCategory()
        {
            if (string.IsNullOrWhiteSpace(NewCategory.Name))
            {
                JS.InvokeVoidAsync("alert", "الرجاء ادخال اسم الصنف");
                return;
            }


            if (!isEditMode)
            {
                if (_categoryService.IsExist(NewCategory.Name))
                {
                    JS.InvokeVoidAsync("alert", "هذا الصنف موجود مسبقا");
                    return;
                }

                var category = new Category
                {
                    Name = NewCategory.Name,
                    Description = NewCategory.Description,
                };

                _categoryService.Add(category);
            }
            else
            {

                Category model = _categoryService.Find(NewCategory.Id);

                model.Name = NewCategory.Name;
                model.Description = NewCategory.Description;
           
                try { 
                    _categoryService.Edit(model);
                }
                catch (Exception ex)
                {
                    JS.InvokeVoidAsync("alert", ex.Message);
                    return;
                }
            }
            NewCategory = new();
            Categories = _categoryService.GetAll();
        }

        // cancel edit
        void Cancel()
        {
            isEditMode = false;
            NewCategory = new Category();
        }

        // edit category

        private void EditCategory(Category model)
        {
            isEditMode = true;

            NewCategory = new Category
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
            };
        }

        // remove category
        private async Task RemoveCategory(Category model)
        {

            var confirm = await JS.InvokeAsync<bool>("confirm", $"هل انت متأكد من حذف {model.Name} ؟");

            if (confirm == true)
            {
                _categoryService.Remove(model.Id);
                Categories = _categoryService.GetAll();
            }
        }

        // filter category
        void changeFilterCategory(Category model)
        {
            FilterCategory = model;
        }
        #endregion
    }
}
