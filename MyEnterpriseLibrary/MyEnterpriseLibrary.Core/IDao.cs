using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEnterpriseLibrary.Core
{
    public interface IDao<Book>
    {
        bool Add(Book t);
        bool Update(Book t, string id);
        List<Book> GetAll();

    }
}
