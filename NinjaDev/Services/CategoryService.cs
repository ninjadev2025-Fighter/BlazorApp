using NinjaDev.Data.Context;
using NinjaDev.Domain;

namespace NinjaDev.Services
{
    public class CategoryService
    {


        AppDbContext db;
        public CategoryService(AppDbContext _db)
        {
            db = _db;
        }



        public void Add(Category category)
        {
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

    }
}
