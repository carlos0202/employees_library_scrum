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
            Books = new List<Book>();
            Employees = new List<Employee>();
        }

        public List<Book> Books { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
