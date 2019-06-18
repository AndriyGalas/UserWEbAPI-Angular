using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserProject.Models.Interfaces
{
    public interface IService<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        Task Add(T item);
        Task Remove(int id);
        Task Update(int id, T newBook);
    }
}
