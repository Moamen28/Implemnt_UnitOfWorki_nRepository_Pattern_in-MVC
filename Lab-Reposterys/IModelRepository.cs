using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Reposterys
{
    public interface IModelRepository<T>
    {
        void Add(T Entity);

        //we need to make a class that contain id to specify that each class has id so i must declare a base class contain id
        T GetById(int ID);

        void Remove(T ID);

        void Update(T Entity, long id);

        IQueryable<T> GetAll();
    }
}