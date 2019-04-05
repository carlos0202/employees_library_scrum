using System;
using System.Collections.Generic;
using System.Linq;

namespace MyEnterpriseLibrary.Core
{
    public class BookDAO: IDao
    {
        private List<Book> _books;

        public BookDAO()
        {
            _books = new List<Book>();
        }

        public bool Add(Book book)
        {
            if(_books.Any(b => b.ISBN == book.ISBN))
            {
                throw new ArgumentException("A book with this ISBN already exists.");
            }

            if(book.ISBN == null)
            {
                throw new ArgumentNullException(null, "ISBN cannot be null.");
            }

            if (book.Title == null)
            {
                throw new ArgumentNullException(null, "Title cannot be null.");
            }

            if (book.Authors == null)
            {
                throw new ArgumentNullException(null, "Author cannot be null.");
            }

            _books.Add(book);

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
    }
}