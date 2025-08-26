using Microsoft.JSInterop;
using NinjaDev.Data.Context;
using NinjaDev.Domain;
using System.Threading.Tasks;

namespace NinjaDev.Components.Pages
{
    public partial class Home
    {

        AppDbContext db;
        private List<Category> Categories = new();

        public Category NewCategory { get; set; } = new();



        public Home(AppDbContext _db)
        {
            db = _db;

            Categories = GetCategoriesData();
        }


        void AddCategory()
        {

            if (db.Categories.Where(x => x.Name == NewCategory.Name).Count() > 0)
            {
                JS.InvokeVoidAsync("alert", "هذا الصنف موجود مسبقا");
                return;
            }

            var category = new Category
            {
                Name = NewCategory.Name,
                Description = NewCategory.Description,
            };

            AddCategory(category);

            db.SaveChanges();

            Categories = GetCategoriesData();
        }








        // Database Operations of Category Entity

        private void AddCategory(Category category)
        {
            db.Categories.Add(category);
        }

        private List<Category> GetCategoriesData()
        {
            return db.Categories.ToList();
        }

        private async Task RemoveCategory(Category model)
        {

            var confirm = await JS.InvokeAsync<bool>("confirm", $"هل انت متأكد من حذف {model.Name} ؟");

            if (confirm == true)
            {
                db.Categories.Remove(model);
                db.SaveChanges();

                Categories.Remove(model);
            }
        }
    }
}
