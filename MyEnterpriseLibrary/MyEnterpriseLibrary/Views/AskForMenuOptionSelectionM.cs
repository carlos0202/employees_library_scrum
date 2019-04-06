using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEnterpriseLibrary.Views
{
    public static class AskForMenuOptionSelectionM
    {
        public static int AskForMenuOptionSelection(this Coordinator c)
        {
            Console.Write("Please select an option: ");
            int option = -1;
            try
            {
                option = c.CatchMenuOption();

            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine(ex.Message);
                option = c.AskForMenuOptionSelection();

            }

            return option;
        }
    }
}
