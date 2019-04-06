using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace MyEnterpriseLibrary.Core
{
    class BookDaoPROD : IDao
    {
        private List<Book> _books;
        private string _dbUrl = "/Books.json";
        public BookDaoPROD()
        {
            using(StreamReader r = new StreamReader(Directory.GetCurrentDirectory() + _dbUrl))
            {
                string json = r.ReadToEnd();
                _books = JsonConvert.DeserializeObject<List<Book>>(json);
            }
        }

        public bool Add(Book t)
        {
            throw new NotImplementedException();
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
