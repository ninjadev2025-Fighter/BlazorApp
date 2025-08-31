using NinjaDev.Data.Context;
using NinjaDev.Domain;

namespace NinjaDev.Services
{
    public class CategoryService
    {
        private AppDbContext _db;

        public CategoryService(AppDbContext db)
        {
            _db = db;
        }


        public void Add(Category category)
        {
            _db.Categories.Add(category);
            _db.SaveChanges();
        }


        public List<Category> GetAll()
        {
            return _db.Categories.ToList();
        }



        public bool IsExist(string name)
        {
            return _db.Categories.Any(c => c.Name == name);
        }


        public void Remove(int id)
        {
            var entity = _db.Categories.Find(id);

            if (entity != null)
            {
                _db.Categories.Remove(entity);
                _db.SaveChanges();
            }
        }
    }
}
