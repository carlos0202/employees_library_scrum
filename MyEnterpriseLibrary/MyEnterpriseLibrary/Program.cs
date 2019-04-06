using MyEnterpriseLibrary.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEnterpriseLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            // Arrange
            var book = new Book(iSBN: "A123456Z", title: "Platero y yo", Authors: "Pedro Pablo Leon Jaramillo");
            IDao bookDAO = new BookDaoPROD();

            // Act
            bool expectedResult = bookDAO.Add(book);
        }
    }
}
