using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEnterpriseLibrary.Views
{
    public static class PrintMenuM
    {
        public static void PrintMenu(this Coordinator c, string[] menuItemsList)
        {
            Console.WriteLine("");
            foreach (string item in menuItemsList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("");
        }
    }
}
