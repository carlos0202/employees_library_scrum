using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEnterpriseLibrary.Core
{
    public interface IDao<Book>
    {
        bool add(Book t);
        bool update(Book t, string id);
        List<Book> getAll();

    }
}
