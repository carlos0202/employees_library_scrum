using System;
using System.Collections.Generic;
using System.Linq;

namespace MyEnterpriseLibrary.Core
{
    public class BookDAO
    {
        private List<Book> _books;

        public BookDAO()
        {
            _books = new List<Book>();

        }

        public bool AddBook(Book book)
        {
            if(_books.Any(b => b.ISBN == book.ISBN))
            {
                throw new InvalidOperationException("This book already exists in the database.");
            }

            if(book.ISBN == null)
            {
                throw new ArgumentNullException(null, "ISBN cannot be null.");
            }

            if (book.Title == null)
            {
                throw new ArgumentNullException(null, "Title cannot be null.");
            }

            _books.Add(book);

            return true;
        }

        internal Book FindById(string bookId)
        {
            throw new NotImplementedException();
        }

        public bool Lend(string bookId, int employeeId)
        {
            BookDAO bookDAO = new BookDAO();
            EmployeeDao employeeDAO = new EmployeeDao();

            Book book = bookDAO.FindById(bookId);
            Employee employee = employeeDAO.FindById(employeeId);

            if (book == null)
            {
                throw new ArgumentException("Book cannot no be found");
            }

            if (employee == null)
            {
                throw new ArgumentException("Employee cannot no be found");
            }
            

            return true;
        }
    }
}