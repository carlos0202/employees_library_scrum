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
    class LendBookTest
    {
        public void lend_book_to_employee() {
            //Arrange
            Book book = new Book("E0", "wawawa", "WawaWa1,wawawa2");
            BookLender bookLender = new BookLender();
            //Act
            bool result = bookLender.lend(book, employeeId);
            //Assert
            Assert.That(result, Is.EqualTo(true));
        }
    }
}
