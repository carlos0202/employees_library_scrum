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
    public class BookListTests
    {

        [Test]
        public void List_AllBooks()
        {
            // Arrange
            IDao dao = new BookDAO();
            dao.Add(new Book("ABC", "Libro Prueba", "JNovas"));
            dao.Add(new Book("CDE", "Libro Prueba", "JNovas"));
            dao.Add(new Book("DEF", "Libro Prueba", "JNovas"));

            // Act
            int booksCount = dao.GetAll().Count;

            // Act + Assert
            Assert.That(booksCount, Is.EqualTo(3));
        }
    }
}
