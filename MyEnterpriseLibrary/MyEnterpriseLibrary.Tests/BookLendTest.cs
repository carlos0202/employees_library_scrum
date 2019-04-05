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
        public void lend_book_to_employee() {
            //Arrange
            string bookId = "E0";
            int employeeId = 1;
            BookLender bookLender = new BookLender();
            //Act
            bool status = bookLender.lend(bookId, employeeId);
            //Assert
            Assert.That(status, Is.EqualTo(true));
        }
    }
}
