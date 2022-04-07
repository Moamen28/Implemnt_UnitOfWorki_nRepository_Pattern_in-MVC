using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Data
{
    public interface IContextFactory
    {
        DbContext GetContext();
    }
}