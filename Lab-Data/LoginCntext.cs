using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab_Model;

namespace Lab_Data
{
    public class LoginCntext : DbContext
    {
        public LoginCntext() : base("Data Source=.;Initial Catalog=labDay5DB;Integrated Security=True")
        {
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Student> Students { get; set; }
    }
}