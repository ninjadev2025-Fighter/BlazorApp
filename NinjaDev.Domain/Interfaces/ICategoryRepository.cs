using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaDev.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        void Add(Category category);
        void Edit(Category category);
        void Remove(int id);
        Category Find(int id);
        List<Category> GetAll();

        bool IsExist(string CategoryName);
    }
}
