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
        private List<Book> _books;
        private string _dbUrl = "/DB.json";
        public BookDaoPROD()
        {
            using(StreamReader r = new StreamReader(Directory.GetCurrentDirectory() + _dbUrl))
            {
                string json = r.ReadToEnd();
                try
                {
                    var _db = JsonConvert.DeserializeObject(json);
                }
                catch {
                }
                
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

        private bool Conne
    }
}
