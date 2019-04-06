using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace MyEnterpriseLibrary.Core
{
    public class BookDaoPROD : IDao
    {
        private DB db;
        private string _dbUrl = "DB.json";
        public BookDaoPROD()
        {
            db = new DB();
            GetDb();
        }

        public bool Add(Book t)
        {
            if (db.Books.Any(b => b.ISBN == t.ISBN))
            {
                throw new ArgumentException("A book with this ISBN already exists.");
            }

            if (t.ISBN == null)
            {
                throw new ArgumentNullException(null, "ISBN cannot be null.");
            }

            if (t.Title == null)
            {
                throw new ArgumentNullException(null, "Title cannot be null.");
            }

            if (t.Authors == null)
            {
                throw new ArgumentNullException(null, "Author cannot be null.");
            }

            db.Books.Add(t);

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


        protected void GetDb()
        {
            using (StreamReader r = new StreamReader(Directory.GetCurrentDirectory() + "/" +  _dbUrl))
            {
                string json = r.ReadToEnd();
                try
                {
                    dynamic _db = JsonConvert.DeserializeObject<Db>(json);
                }
                catch
                {
                }

            }
        }

        protected void FlushDb()
        {
            // serialize JSON directly to a file again
            using (StreamWriter file = File.CreateText(_dbUrl))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, db);
            }
        }

        public Book FindById(string bookId)
        {
            return db.Books.Find(b => b.ISBN == bookId);
        }

        public bool Lend(string bookId, int employeeId)
        {
            Book book = FindById(bookId);
            Employee employee = db.Employees
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
            FlushDb();

            return true;
        }
    }

    internal class Db
    {
        public List<Book> Books { get; set; }
        public object Employees { get; set; }
    }
}
