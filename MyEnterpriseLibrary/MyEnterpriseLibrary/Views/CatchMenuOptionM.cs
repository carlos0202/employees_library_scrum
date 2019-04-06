using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEnterpriseLibrary.Views
{
    public static class CatchMenuOptionM
    {
        public static int CatchMenuOption(this Coordinator c)
        {
            int currentOption = -1;
            ConsoleKeyInfo cki = Console.ReadKey();
            try
            {
                currentOption = Convert.ToInt32(cki.KeyChar.ToString());
            }
            catch (Exception)
            {
                throw new ArgumentException("Option is not valid.");
            }

            return currentOption;
        }
    }
}
