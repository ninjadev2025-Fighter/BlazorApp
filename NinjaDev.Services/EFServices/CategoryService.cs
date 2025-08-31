using NinjaDev.Data.Context;
using NinjaDev.Domain;
using NinjaDev.Domain.Interfaces;
using System;

namespace NinjaDev.Services
{
    public class CategoryService : ICategoryRepository
    {


        AppDbContext db;
        public CategoryService(AppDbContext _db)
        {
            db = _db;
        }



        public void Add(Category category)
        {
            category.CreatedAt = DateTime.Now;
            db.Categories.Add(category);
            db.SaveChanges();
        }

        public List<Category> GetAll()
        {
            return db.Categories.ToList();
        }

        public void Remove(int id)
        {
            var entity = db.Categories.Find(id);

            if (entity != null)
            {
                db.Categories.Remove(entity);
                db.SaveChanges();
            }
        }


        public bool IsExist(string CategoryName)
        {
            return db.Categories.Any(x => x.Name == CategoryName);
        }

        public void Edit(Category category)
        {
            var oldcat = db.Categories.FirstOrDefault(x => x.Name == category.Name && x.Id != category.Id);
            if (oldcat != null)
                throw new InvalidOperationException("هذا الصنف موجود مسبقا");

            var model = db.Categories.Find(category.Id);
            model.Name = category.Name;
            model.Description = category.Description;
            model.UpdatedAt = DateTime.Now;


            db.SaveChanges();
        }

        public Category Find(int id)
        {
            return db.Categories.Find(id);
        }
    }
}
