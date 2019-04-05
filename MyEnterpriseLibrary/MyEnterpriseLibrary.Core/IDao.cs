using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEnterpriseLibrary.Core
{
    interface IDao<T>
    {
        bool add(T t);
        bool update(T t, string id);
        List<T> getAll();

    }
}
