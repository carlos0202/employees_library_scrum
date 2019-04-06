namespace MyEnterpriseLibrary.Core
{
    public class Book
    {
        public string Authors {
            get; set; 
        }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Estatus { get; set; }

        public Book(string iSBN, string title, string Authors)
        {
            this.ISBN = iSBN;
            this.Title = title;
            this.Authors = Authors;
        }
    }
}