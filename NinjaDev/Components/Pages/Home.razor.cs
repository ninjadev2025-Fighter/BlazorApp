using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using NinjaDev.Data.Context;
using NinjaDev.Domain;
using NinjaDev.Domain.Interfaces;
using NinjaDev.Services;
using System.Runtime.CompilerServices;
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
        public Category FilterCategory { get; set; } = new();


        // initializing states
        private bool isEditMode { get; set; } = false;

        //image upload
        private string ImagePreview;
        private IBrowserFile UploadedFile;



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



        //choose photo
        private async Task HandleFileSelected(InputFileChangeEventArgs e)
        {
            UploadedFile = e.File;

            // قراءة الصورة للعرض الفوري
            using var ms = new MemoryStream();
            await UploadedFile.OpenReadStream(10 * 1024 * 1024).CopyToAsync(ms);
            
            ImagePreview = $"data:{UploadedFile.ContentType};base64,{Convert.ToBase64String(ms.ToArray())}";

        }










        private async Task SaveCategory()
        {
            if (string.IsNullOrWhiteSpace(NewCategory.Name))
            {
                await JS.InvokeVoidAsync("alert", "الرجاء ادخال اسم الصنف");
                return;
            }


            if (!isEditMode)
            {
                if (_categoryService.IsExist(NewCategory.Name))
                {
                    await JS.InvokeVoidAsync("alert", "هذا الصنف موجود مسبقا");
                    return;
                }

                var category = new Category
                {
                    Name = NewCategory.Name,
                    Description = NewCategory.Description,
                };








                // حفظ الصورة إذا تم رفعها
                if (UploadedFile != null)
                {
                    var folderPath = Path.Combine("wwwroot", "uploads", "categories");
                    if (!Directory.Exists(folderPath))
                        Directory.CreateDirectory(folderPath);

                    var fileName = $"{Guid.NewGuid()}{Path.GetExtension(UploadedFile.Name)}";
                    var filePath = Path.Combine(folderPath, fileName);
                   
                    using var stream = new FileStream(filePath, FileMode.Create);
                    await UploadedFile.OpenReadStream(10 * 1024 * 1024).CopyToAsync(stream);
                   
                    category.ImageUrl = $"/uploads/categories/{fileName}";
                }






                _categoryService.Add(category);
            }
            else
            {

                Category model = _categoryService.Find(NewCategory.Id);

                model.Name = NewCategory.Name;
                model.Description = NewCategory.Description;




                // تحديث الصورة إذا تم رفع صورة جديدة
                if (UploadedFile != null)
                {
                    var folderPath = Path.Combine("wwwroot", "uploads", "categories");
                    if (!Directory.Exists(folderPath))
                        Directory.CreateDirectory(folderPath);

                    var fileName = $"{Guid.NewGuid()}{Path.GetExtension(UploadedFile.Name)}";
                    var filePath = Path.Combine(folderPath, fileName);
                    using var stream = new FileStream(filePath, FileMode.Create);
                    await UploadedFile.OpenReadStream(10 * 1024 * 1024).CopyToAsync(stream);
                    model.ImageUrl = $"/uploads/categories/{fileName}";
                }



                try
                {
                    _categoryService.Edit(model);
                }
                catch (Exception ex)
                {
                    await JS.InvokeVoidAsync("alert", ex.Message);
                    return;
                }
            }
            NewCategory = new();
            UploadedFile = null;
            ImagePreview = null;
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

            ImagePreview = !string.IsNullOrEmpty(model.ImageUrl) ? model.ImageUrl : null;

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
