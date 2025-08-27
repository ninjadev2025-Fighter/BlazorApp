using Microsoft.JSInterop;
using NinjaDev.Data.Context;
using NinjaDev.Domain;
using NinjaDev.Services;
using System.Threading.Tasks;

namespace NinjaDev.Components.Pages
{
    public partial class Home
    {

       
        CategoryService _categoryService;


        private List<Category> Categories = new();

        public Category NewCategory { get; set; } = new();



        public Home(CategoryService categoryService)
        {
            _categoryService = categoryService;

            Categories = _categoryService.GetAll();
        }


        void AddCategory()
        {
            if (string.IsNullOrEmpty( NewCategory.Name))
            {
                JS.InvokeVoidAsync("alert", "ادخل الاسم اولا ! ");
                return;
            }

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

            Categories = _categoryService.GetAll();
        }

        private async Task RemoveCategory(Category model)
        {

            var confirm = await JS.InvokeAsync<bool>("confirm", $"هل انت متأكد من حذف {model.Name} ؟");

            if (confirm == true)
            {
                _categoryService.Remove(model.Id);
                Categories = _categoryService.GetAll();
            }
        }
   
    
    }
}
