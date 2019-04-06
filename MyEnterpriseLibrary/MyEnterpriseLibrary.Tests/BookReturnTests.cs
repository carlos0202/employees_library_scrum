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
    class BookReturnTests
    {

        [Test]
        public void Return_Book_From_Employee() {
            //Arrange
            string bookId = "E0";
            int employeeId = 1;
            BookDAO dao = new BookDAO();

            //Act
            dao.Add(new Book(bookId, "Libro Prueba", "JNovas"));
            dao.Lend(bookId, employeeId);
            bool status = dao.Return(bookId);

            //Assert
            Assert.That(status, Is.EqualTo(true));
        }


        [Test]
        public void Return_Book_From_BookId_null()
        {
            //Arrange
            string bookId = null;
            BookDAO dao = new BookDAO();

            //Act
            dao.Add(new Book(bookId, "Libro Prueba", "JNovas"));

            //Assert
            Assert.That(() => dao.Return(bookId),
                Throws.ArgumentNullException.With.Message.EqualTo("ISBN cannot be null."));
        }
    }
}
