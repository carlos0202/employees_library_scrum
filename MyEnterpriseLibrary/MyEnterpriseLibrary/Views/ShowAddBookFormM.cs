using MyEnterpriseLibrary.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEnterpriseLibrary.Views
{
    public static class ShowAddBookFormM
    {
        public static void ShowAddBookForm(this Coordinator c)
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
                Program.Main(null);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }
    }
}
