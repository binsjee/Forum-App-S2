using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseLayer.Interfaces
{
    public interface IGenericQueries<T>
    {
        List<T> GetAll();
        T GetById(int id);

    }
}
