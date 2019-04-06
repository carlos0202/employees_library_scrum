using MyEnterpriseLibrary.Core;
using System;

namespace MyEnterpriseLibrary
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.Title = "BookApp";
            PrintAppHeader();
            ManageMainMenu();
            Console.ReadKey();
        }


        private static void PrintAppHeader()
        {
            Console.WriteLine(@"  ____              _                          
 |  _ \            | |       /\                
 | |_) | ___   ___ | | __   /  \   _ __  _ __  
 |  _ < / _ \ / _ \| |/ /  / /\ \ | '_ \| '_ \ 
 | |_) | (_) | (_) |   <  / ____ \| |_) | |_) |
 |____/ \___/ \___/|_|\_\/_/    \_\ .__/| .__/ 
                                  | |   | |    
                                  |_|   |_|    
");
        }

        private static void ManageMainMenu()
        {
            string[] menuItemsList = { "1--> Add Book", "0--> Salir" };
            Console.WriteLine("******* Main Menu **********");
            PrintMenu(menuItemsList);
            int optionSelect = AskForMenuOptionSelection();
            HandlerOptionSelected(optionSelect);
        }

        private static void HandlerOptionSelected(int op)
        {
            switch (op)
            {
                case 1:
                    ShowAddBookForm();
                    break;
                case 0:
                    Environment.Exit(0);
                    break;

            }
        }

        private static void PrintMenu(string[] menuItemsList)
        {
            Console.WriteLine("");
            foreach (string item in menuItemsList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("");
        }

        private static int AskForMenuOptionSelection()
        {
            Console.Write("Please select an option: ");
            int option = -1;
            try
            {
                option = CatchMenuOption();

            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine(ex.Message);
                option = AskForMenuOptionSelection();

            }

            return option;
        }

        private static int CatchMenuOption()
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

        private static void ShowAddBookForm()
        {
            string iSBN = string.Empty;
            string Title = string.Empty;
            string Authors = string.Empty;

            Console.Clear();
            Console.WriteLine("***********Add a new Book***********");
            Console.Write("Write iSBN: ");
            iSBN = Console.ReadLine();
            Console.Write("Write Title: ");
            Title = Console.ReadLine();
            Console.Write("Write Authors: ");
            Authors = Console.ReadLine();

            Book b = new Book(iSBN: iSBN,
                title: Title,
                authors: Authors);

            IDao bookDao = new BookDaoPROD();
            try
            {
                bookDao.Add(b);
                Console.WriteLine("Book Added Sucesfully.");
                Console.WriteLine();
                Console.WriteLine("Press any key to return to Main Menu");
                Console.ReadKey();
                Console.Clear();
                Main(null);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }

    }
}
