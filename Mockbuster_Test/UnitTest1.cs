using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Mockbuster;

namespace Mockbuster_Test
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void User_CanBorrowAndReturnItem()
        {
            // Arrange
            var user = new User("Alice");
            var item = new Item("Digital Book");
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            // Act
            user.BorrowItem(item);
            user.ViewBorrowedItems();
            string borrowedOutput = consoleOutput.ToString().Trim();

            consoleOutput.GetStringBuilder().Clear();

            user.ReturnItem(item);
            user.ViewBorrowedItems();
            string returnedOutput = consoleOutput.ToString().Trim();

            // Assert
            Assert.AreEqual("Digital Book", borrowedOutput); // Item should appear when borrowed
            Assert.AreEqual("", returnedOutput); // List should be empty after returning
        }
    }
}