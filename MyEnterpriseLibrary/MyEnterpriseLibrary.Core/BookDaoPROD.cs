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
        private string _dbUrl = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\DB.json";
        public BookDaoPROD()
        {
            db = new DB();
            GetDb();
        }

        public bool Add(Book t)
        {
            GetDb();
            if (db.books.Any(b => b.ISBN == t.ISBN))
            {
                throw new ArgumentException("A book with this ISBN already exists.");
            }

            if (string.IsNullOrEmpty(t.ISBN))
            {
                throw new ArgumentNullException(null, "ISBN cannot be null.");
            }

            if (string.IsNullOrEmpty(t.Title))
            {
                throw new ArgumentNullException(null, "Title cannot be null.");
            }

            if (string.IsNullOrEmpty(t.Authors))
            {
                throw new ArgumentNullException(null, "Author cannot be null.");
            }

            db.books.Add(t);
            FlushDb();

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
            try
            {
                using (StreamReader r = new StreamReader(_dbUrl))
                {
                    string json = r.ReadToEnd();

                    dynamic _db = JsonConvert.DeserializeObject<Db>(json);
                }
            }
            catch
            {
                string rootJson = "{\"books\": [], \"employees\": [] }";
                File.WriteAllText(_dbUrl, rootJson);
                dynamic _db = JsonConvert.DeserializeObject<Db>(rootJson);
            }
        }

        protected void FlushDb()
        {
            // serialize JSON directly to a file again
            string newDbData = JsonConvert.SerializeObject(db, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(_dbUrl, newDbData);
        }

        public Book FindById(string bookId)
        {
            return db.books.Find(b => b.ISBN == bookId);
        }

        public bool Lend(string bookId, int employeeId)
        {
            GetDb();
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
            FlushDb();

            return true;
        }

        public bool Return(string bookId)
        {
            throw new NotImplementedException();
        }
    }
}
