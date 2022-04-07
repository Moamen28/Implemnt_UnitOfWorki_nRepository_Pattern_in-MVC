using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Data
{
    public class ContextFactory : IContextFactory
    {
        private readonly DbContext context;

        public ContextFactory()
        {
            context = context == null ? new LoginCntext() : context;
        }

        public DbContext GetContext()
        {
            return context;
        }
    }
}