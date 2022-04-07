using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Lab_Data;
using lab_Model;

namespace Lab_Reposterys
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext Context;
        private IModelRepository<User> UserRepo;
        private IModelRepository<Student> StudentRepo;

        //here we will the factory context as factory is the only one responsiple for creating the context
        public UnitOfWork(IContextFactory _ContextFactory, IModelRepository<User> _modelRepository, IModelRepository<Student> _smodelRepository)
        {
            Context = _ContextFactory.GetContext();
            UserRepo = _modelRepository;
            StudentRepo = _smodelRepository;
        }

        public IModelRepository<User> Getuserrepo()
        {
            return UserRepo;
        }

        public IModelRepository<Student> GetStudentrepo()
        {
            return StudentRepo;
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}