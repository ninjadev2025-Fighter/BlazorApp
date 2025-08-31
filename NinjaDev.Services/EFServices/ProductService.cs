using NinjaDev.Data.Context;
using NinjaDev.Domain;
using NinjaDev.Domain.Interfaces;
using System;

namespace NinjaDev.Services
{
    public class ProductService : IProductRepository
    {


        AppDbContext db;
        public ProductService(AppDbContext _db)
        {
            db = _db;
        }



        public List<Product> GetAll()
        {
            return db.Products.ToList();
        }


        public List<Product> GetByCategory(int catid)
        {
            return db.Products.Where(x=>x.CategoryId == catid).ToList();
        }


















        //public void Add(Product product)
        //{
        //    product.CreatedAt = DateTime.Now;
        //    db.Products.Add(product);
        //    db.SaveChanges();
        //}


        //public void Remove(int id)
        //{
        //    var entity = db.Products.Find(id);

        //    if (entity != null)
        //    {
        //        db.Products.Remove(entity);
        //        db.SaveChanges();
        //    }
        //}


        //public bool IsExist(string CategoryName)
        //{
        //    return db.Products.Any(x => x.Name == CategoryName);
        //}

        //public void Edit(Product product)
        //{
        //    var oldcat = db.Products.FirstOrDefault(x => x.Name == product.Name && x.Id != product.Id);
        //    if (oldcat != null)
        //        throw new InvalidOperationException("هذا الصنف موجود مسبقا");

        //    var model = db.Products.Find(product.Id);
        //    model.Name = product.Name;
        //    model.Price = product.Price;
        //    model.UpdatedAt = DateTime.Now;


        //    db.SaveChanges();
        //}

        //public Product Find(int id)
        //{
        //    return db.Products.Find(id);
        //}
    }
}
