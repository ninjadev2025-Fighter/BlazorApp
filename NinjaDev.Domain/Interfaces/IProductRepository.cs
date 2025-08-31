using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaDev.Domain.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        List<Product> GetByCategory(int catid);

    }
}


















//void Add(Product product);
//void Edit(Product product);
//void Remove(int id);
//Product Find(int id);

//bool IsExist(string productName);
