using System;
using System.Collections.Generic;
using System.Linq;

namespace MyEnterpriseLibrary.Core
{
    public class BookDAO : IDao
    {
        private DB db;

        public BookDAO()
        {
            db = new DB();
            db.employees = new List<Employee>();

            db.employees.Add(new Employee
            {
                Id = 1,
                Name = "Omar",
                DepartmentId = 2
            });
            db.employees.Add(new Employee
            {
                Id = 2,
                Name = "Jnovas",
                DepartmentId = 3
            });
        }

        public bool Add(Book book)
        {
            if (db.books.Any(b => b.ISBN == book.ISBN))
            {
                throw new ArgumentException("A book with this ISBN already exists.");
            }

            if (string.IsNullOrEmpty(book.ISBN) || 
                string.IsNullOrWhiteSpace(book.ISBN.Trim()))
            {
                throw new ArgumentNullException(null, "ISBN cannot be null.");
            }

            if (string.IsNullOrEmpty(book.Title) ||
                string.IsNullOrEmpty(book.Title.Trim()))
            {
                throw new ArgumentNullException(null, "Title cannot be null.");
            }

            if (string.IsNullOrEmpty(book.Authors) || 
                string.IsNullOrEmpty(book.Authors.Trim()))
            {
                throw new ArgumentNullException(null, "Author cannot be null.");
            }

            db.books.Add(book);

            return true;
        }

        public List<Book> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(Book t, string id)
        {
            throw new NotImplementedException();
        }

        public bool Lend(string bookId, int employeeId)
        {
            Book book = FindById(bookId);
            Employee employee = db.employees
                .FirstOrDefault(e => e.Id == employeeId);

            if (book == null)
            {
                throw new ArgumentException("Book cannot be found");
            }

            if (employee == null)
            {
                throw new ArgumentException("Employee cannot be found");
            }

            if (book.Estatus == BookStatus.Lent)
            {
                throw new Exception("The book is already Lent");
            }

            book.Estatus = BookStatus.Lent;

            return true;
        }

        public Book FindById(string bookId)
        {
            return db.books.FirstOrDefault(b => b.ISBN == bookId);
        }

        public bool Return(string bookId)
        {
            if (string.IsNullOrEmpty(bookId))
            {
                throw new ArgumentNullException(null, "ISBN cannot be null");
            }

            Book book = FindById(bookId);

            if(book == null)
            {
                throw new InvalidOperationException("No book exists with the given ISBN");
            }

            if (book.Estatus == BookStatus.Available)
            {
                throw new InvalidOperationException("This book was not given to anyone");
            }

            book.Estatus = BookStatus.Available;

            return true;
        }
    }
}