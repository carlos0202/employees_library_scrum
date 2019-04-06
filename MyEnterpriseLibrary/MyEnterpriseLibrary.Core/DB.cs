using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEnterpriseLibrary.Core
{
    public class DB
    {
        public DB()
        {
            books = new List<Book>();
            employees = new List<Employee>();
        }

        public List<Book> books { get; set; }
        public List<Employee> employees { get; set; }
    }
}
