using MyEnterpriseLibrary.Core;
using System;
using System.Collections.Generic;
using System.Linq;

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
            string[] menuItemsList = { "1--> Add Book","2--> Lend a book", "3--> Return a book","4--> List All Books", "0--> Salir" };
            Console.WriteLine("******* Main Menu **********");
            PrintMenu(menuItemsList);
            int optionSelect = AskForMenuOptionSelection();
            HandlerOptionSelected(optionSelect);

            Main(null);
        }

        private static void HandlerOptionSelected(int op)
        {
            switch (op)
            {
                case 1:
                    ShowAddBookForm();
                    break;
                case 2:
                    ShowLendBookForm();
                    break;
                case 3:
                    ShowReturnBookForm();
                    break;
                case 4:
                    ShowBookList();
                    break;
                case 0:
                    Console.WriteLine("Are you sure you want to exits the app (y/n)?");
                    Console.WriteLine("Are you sure you want to exits the app?");
                    Console.ReadKey();
                    Environment.Exit(0);
                    break;

            }
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

            Book b = new Book(iSBN: iSBN.Trim(),
                title: Title.Trim(),
                authors: Authors.Trim());

            IDao bookDao = new BookDaoPROD();
            try
            {
                bookDao.Add(b);

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Book Added Sucesfully.");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine();
                Console.WriteLine("Press any key to return to Main Menu");
                Console.ReadKey();
                Console.Clear();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Press any key to return to Main Menu");                
                Console.ReadKey();
                Console.Clear();
            }

        }

        private static void ShowLendBookForm()
        {
            string iSBN = string.Empty;
            int employeeId = -1;

            Console.Clear();
            Console.WriteLine("***********Lend a Book to an employee ***********");
            Console.Write("Book ISBN: ");
            iSBN = Console.ReadLine();
            Console.Write("Employee Id: ");
            
            int.TryParse(Console.ReadLine().ToString(), out employeeId);

            IDao bookDao = new BookDaoPROD();
            try
            {
                bookDao.Lend(iSBN.Trim(), employeeId);
                Console.WriteLine("Book lent Sucesfully.");
                Console.WriteLine();
                Console.WriteLine("Press any key to return to Main Menu");
                Console.ReadKey();
                Console.Clear();
                Main(null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Press any key to return to Main Menu");
                Console.ReadKey();
                Console.Clear();
            }

        }

        private static void ShowReturnBookForm()
        {
            string iSBN = string.Empty;

            Console.Clear();
            Console.WriteLine("***********Returning a Book ***********");
            Console.Write("Book ISBN: ");
            iSBN = Console.ReadLine();

            IDao bookDao = new BookDaoPROD();
            try
            {
                bookDao.Return(iSBN.Trim());
                Console.WriteLine("Book returned Sucesfully.");
                Console.WriteLine();
                Console.WriteLine("Press any key to return to Main Menu");
                Console.ReadKey();
                Console.Clear();
                Main(null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Press any key to return to Main Menu");
                Console.ReadKey();
            }

        }

        private static void ShowBookList()
        {
            Console.Clear();
            Console.WriteLine("*********** List of Books ***********");
            Console.WriteLine("--------------------------------------------------------------------------------");

            BookDaoPROD bookDao = new BookDaoPROD();
            List<Book> listBooks = bookDao.GetAll();

            listBooks = listBooks.OrderBy(book => book.Title).ToList();

            if(listBooks.Count > 0)
            {
                Console.WriteLine("iSBN\t\t|\t\tTitle\t\t|\t\tAuthors");
                Console.WriteLine("--------------------------------------------------------------------------------");

                foreach (Book b in listBooks)
                {
                    Console.WriteLine($"{b.ISBN}\t\t|\t\t{b.Title}\t\t|\t\t{b.Authors}");
                }
                
            }
            else
            {
                Console.WriteLine("There is not books registered.");
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to return to Main Menu");
            Console.ReadKey();
            Console.Clear();
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
            string option = Console.ReadLine();
            try
            {
                currentOption = Convert.ToInt32(option);
            }
            catch (Exception)
            {
                throw new ArgumentException("Option is not valid.");
            }

            return currentOption;
        }
        

    }
}
