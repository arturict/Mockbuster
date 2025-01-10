using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Mockbuster;
using System.Linq;

namespace Mockbuster_Test
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void BorrowBook_BookIsBorrowedSuccessfully()
        {
            // Arrange
            var user = new User("Alice");
            var book = new Book("Digital Book", "Author XY", "111-222-333");
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            // Act
            user.BorrowItem(book);
            user.ViewBorrowedItems();
            var output = consoleOutput.ToString().Trim();

            // Assert
            // Erwartet werden zwei Zeilen:
            // 1) "Alice borrowed Digital Book"
            // 2) "Digital Book"
            var expected = $"{user.Name} borrowed {book.title}{Environment.NewLine}{book.title}";
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void ReturnBook_BookIsReturnedSuccessfully()
        {
            // Arrange
            var user = new User("Alice");
            var book = new Book("Digital Book", "Author XY", "111-222-333");
            user.BorrowItem(book);

            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            // Act
            user.ReturnItem(book);
            user.ViewBorrowedItems();
            var output = consoleOutput.ToString().Trim();

            // Assert
            // Erwartet werden:
            // 1) "Alice returned Digital Book"
            // 2) Danach keine gelisteten Bücher mehr
            var expected = $"{user.Name} returned {book.title}";
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void ViewBorrowedItems_DisplaysAllBorrowedBooks()
        {
            // Arrange
            var user = new User("Alice");
            var book1 = new Book("Digital Book", "Author XY", "111-222-333");
            var book2 = new Book("Der grosse Gatsby", "F. Scott Fitzgerald", "222-333-444");

            user.BorrowItem(book1);
            user.BorrowItem(book2);

            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            // Act
            user.ViewBorrowedItems();
            var output = consoleOutput.ToString().Trim().Split(Environment.NewLine);

            // Assert
            // Erwartet werden beide Titel in jeweils einer Zeile: 
            // "Digital Book"
            // "Der grosse Gatsby"
            Assert.AreEqual(2, output.Length);
            CollectionAssert.Contains(output, book1.title);
            CollectionAssert.Contains(output, book2.title);
        }

        [TestMethod]
        public void GetBorrowedItemByTitle_ReturnsCorrectBook_CaseInsensitive()
        {
            // Arrange
            var user = new User("Alice");
            var book = new Book("Der grosse Gatsby", "F. Scott Fitzgerald", "222-333-444");
            user.BorrowItem(book);

            // Act
            var foundBook = user.GetBorrowedItemByTitle("DER GROSSE gatsby");

            // Assert
            Assert.IsNotNull(foundBook);
            Assert.AreEqual(book.title, foundBook.title);
        }

        [TestMethod]
        public void GetBorrowedItemByTitle_ReturnsNullIfNotBorrowed()
        {
            // Arrange
            var user = new User("Alice");
            var book = new Book("Der grosse Gatsby", "F. Scott Fitzgerald", "222-333-444");
            // Book wurde nicht ausgeliehen

            // Act
            var foundBook = user.GetBorrowedItemByTitle("Der grosse Gatsby");

            // Assert
            Assert.IsNull(foundBook);
        }
    }
}
