using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEnterpriseLibrary.Views
{
    public static class MainMenu
    {
        public static void ManageMainMenu(this Coordinator c)
        {
            string[] menuItemsList = { "1--> Add Book", "0--> Salir" };
            Console.WriteLine("******* Main Menu **********");
            c.PrintMenu(menuItemsList);
            int optionSelect = c.AskForMenuOptionSelection();
            c.HandlerOptionSelected(optionSelect);
        }
    }
}
