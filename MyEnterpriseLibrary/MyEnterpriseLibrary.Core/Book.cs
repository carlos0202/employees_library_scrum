namespace MyEnterpriseLibrary.Core
{
    public class Book
    {
        public string Authors {
            get; set; 
        }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public BookStatus Estatus { get; set; }

        public Book(string iSBN, string title, string authors)
        {
            this.ISBN = iSBN;
            this.Title = title;
            this.Authors = authors;
            this.Estatus = BookStatus.Available;
        }
    }

    public enum BookStatus
    {
        Available,
        Lent
    }
}