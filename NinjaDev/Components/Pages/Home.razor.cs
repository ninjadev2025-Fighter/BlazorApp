using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using NinjaDev.Data.Context;
using NinjaDev.Domain;
using NinjaDev.Services;
using System.Threading.Tasks;

namespace NinjaDev.Components.Pages
{
    public partial class Home
    {
        [Inject] private IJSRuntime JS { get; set; } = default!;

        //AppDbContext db;
        private List<Category> Categories = new();
        CategoryService CategoryService;

        public Category NewCategory { get; set; } = new();



        public Home( CategoryService _categoryService)
        {
            //db = _db;
            CategoryService = _categoryService;

        }
        override protected void OnInitialized()
        {
            Categories = CategoryService.GetAll();
        }

        void AddCategory()
        {

            if (CategoryService.IsExist(NewCategory.Name))
            {
                JS.InvokeVoidAsync("alert", "هذا الصنف موجود مسبقا");
                return;
            }

            var category = new Category
            {
                Name = NewCategory.Name,
                Description = NewCategory.Description,
            };

            CategoryService.Add(category);

            Categories = CategoryService.GetAll();
        }

      







        // Database Operations of Category Entity


        private async Task RemoveCategory(Category model)
        {

            var confirm = await JS.InvokeAsync<bool>("confirm", $"هل انت متأكد من حذف {model.Name} ؟");

            if (confirm == true)
            {
                CategoryService.Remove(model.Id);
                Categories = CategoryService.GetAll();
            }
        }
    }
}
