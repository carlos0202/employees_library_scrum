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
            var bookDAO = new BookDAO();

            // Act
            var expectedResult = bookDAO.AddBook(book);

            // Assert
            Assert.That(expectedResult, Is.EqualTo(true));
        }
    }
}
