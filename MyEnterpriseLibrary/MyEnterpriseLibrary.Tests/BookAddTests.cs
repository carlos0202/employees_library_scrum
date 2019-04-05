using MyEnterpriseLibrary.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEnterpriseLibrary.Tests
{
    [TestFixture]
    public class BookAddTests
    {
        /*
        * 1. Add Book with ISBN, Title and author.
        */
        [Test]
        public void Add_Book_With_All_Info()
        {
            // Arrange
            var book = new Book(iSBN: "A123456Z", title: "Platero y yo", Authors: "Pedro Pablo Leon Jaramillo");
            IDao bookDAO = new BookDAO();

            // Act
            bool expectedResult = bookDAO.Add(book);

            // Assert
            Assert.That(expectedResult, Is.EqualTo(true));
        }

        /*
        * 2. Add Book with no ISBN.
        */
        [Test]
        public void Add_Book_With_Null_ISBN()
        {
            // Arrange
            var book = new Book(iSBN: null, title: "Platero y yo", Authors: "Pedro Pablo Leon Jaramillo");
            IDao bookDAO = new BookDAO();

            // Act + Assert
            Assert.That(() => bookDAO.Add(book), 
                Throws.ArgumentNullException.With.Message.EqualTo("ISBN cannot be null."));
        }

        /*
        * 2. Add Book with no Title.
        */
        [Test]
        public void Add_Book_With_Null_Title()
        {
            // Arrange
            var book = new Book(iSBN: "A123C", title: null, Authors: "Pedro Pablo Leon Jaramillo");
            IDao bookDAO = new BookDAO();

            // Act + Assert
            Assert.That(() => bookDAO.Add(book),
                Throws.ArgumentNullException.With.Message.EqualTo("Title cannot be null."));
        }

        /*
      * 2. Add Book with no Author.
      */
        [Test]
        public void Add_Book_With_Null_Author()
        {
            // Arrange
            var book = new Book(iSBN: "A123C", title: "Platero y yo", Authors: null);
            IDao bookDAO = new BookDAO();

            // Act + Assert
            Assert.That(() => bookDAO.Add(book),
                Throws.ArgumentNullException.With.Message.EqualTo("Author cannot be null."));
        }

        /*
        * 2. Add Book with duplicated ISBN.
        */
        [Test]
        public void Add_Book_With_Duplicated_ISBN()
        {
            // Arrange
            var book = new Book(iSBN: "A123C", title: "Se solto Teodoro", Authors: "Pedro Pablo Leon Jaramillo");
            IDao bookDAO = new BookDAO();
            bookDAO.Add(book);

            // Act + Assert
            Assert.That(() => bookDAO.Add(book),
                Throws.ArgumentException.With.Message.EqualTo("A book with this ISBN already exists."));
        }
    }
}
