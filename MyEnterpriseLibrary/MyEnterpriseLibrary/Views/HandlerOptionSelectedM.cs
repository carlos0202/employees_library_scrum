using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEnterpriseLibrary.Views
{
    public static class HandlerOptionSelectedM
    {
        public static void HandlerOptionSelected(this Coordinator c, int op)
        {
            switch (op)
            {
                case 1:
                    c.ShowAddBookForm();
                    break;
                case 0:
                    Environment.Exit(0);
                    break;

            }
        }
    }
}
