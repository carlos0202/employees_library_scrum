namespace MyEnterpriseLibrary.Core
{
    public class Book
    {
        private string Authors;
        private string iSBN;
        private string title;

        public Book(string iSBN, string title, string Authors)
        {
            this.iSBN = iSBN;
            this.title = title;
            this.Authors = Authors;
        }
    }
}