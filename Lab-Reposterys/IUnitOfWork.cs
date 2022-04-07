using lab_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Reposterys
{
    public interface IUnitOfWork
    {
        IModelRepository<User> Getuserrepo();

        IModelRepository<Student> GetStudentrepo();

        void Save();
    }
}