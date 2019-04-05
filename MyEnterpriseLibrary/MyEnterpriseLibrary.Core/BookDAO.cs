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
        }

        public bool AddBook(Book book)
        {
            if(_books.Any(b => b.ISBN == book.ISBN))
            {
                throw new InvalidOperationException("This book already exists in the database.");
            }

            _books.Add(book);

            return true;
        }
    }
}