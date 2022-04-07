using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_Data;
using System.Data.Entity;
using lab_Model;

namespace Lab_Reposterys
{
    public class ModelRepositery<T> : IModelRepository<T> where T : BaseMode
    {
        private DbContext Context;

        private DbSet<T> Table;

        public ModelRepositery(IContextFactory _ContextFactory)
        {
            Context = _ContextFactory.GetContext();
            Table = Context.Set<T>();
        }

        public void Add(T Entity)
        {
            Table.Add(Entity);
        }

        //we need to make a class that contain id to specify that each class has id so i must declare a base class contain id
        public T GetById(int ID)
        {
            return Table.FirstOrDefault(e => e.ID == ID);
        }

        public void Remove(T s)
        {
            Table.Remove(s);
        }

        public IQueryable<T> GetAll()
        {
            return Table;
        }

        public void Update(T obj, long id)
        {
            var existingEntity = Table.Find(id);
            Context.Entry(existingEntity).CurrentValues.SetValues(obj);
            //var q = sdata.students.FirstOrDefault(s => s.nid == sss.nid);
            //Table.Attach(obj);
            //Context.Entry(obj).State = EntityState.Modified;
        }
    }
}