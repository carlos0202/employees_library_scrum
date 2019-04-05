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
    class BookLendTest
    {

        [Test]
        public void Lend_book_to_employee() {
            //Arrange
            string bookId = "E0";
            int employeeId = 1;
            BookDAO bookLender = new BookDAO();
            //Act
            bool status = bookLender.Lend(bookId, employeeId);
            //Assert
            Assert.That(status, Is.EqualTo(true));
        }

        [Test]
        public void Lend_Book_When_Book_Not_Exist_Throw_ArgumentException()
        {
            //Arrange
            string bookId = null;
            int employeeId = 1;
            BookDAO bookLender = new BookDAO();
            //Assert
            Assert.That(() => bookLender.Lend(bookId, employeeId), Throws.ArgumentException
                .With
                .Message.EqualTo("Book id cannot be found"));
        }
    }


}
