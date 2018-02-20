using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using ToDoList.Models;

namespace ToDoList.Tests
{
  [TestClass]
  public class ItemTest : IDisposable
  {
      public void Dispose()
      {
        Item.DeleteAll();
      }
      public void ItemTests()
      {
        DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=todo_test;";
      }

      [TestMethod]
        public void GetAll_DatabaseEmptyAtFirst_0()
        {
          //Arrange, Act
          int result = Item.GetAll().Count;

          //Assert
          Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void GetDescription_ReturnsDescription_String()
        {
          //Arrange
          string description = "Walk the dog.";
          Item newItem = new Item(description);

          //Act
          string result = newItem.GetDescription();

          //Assert
          Assert.AreEqual(description, result);
        }

        [TestMethod] //this test does not pass since the database was added
        public void GetAll_ReturnsItems_ItemList()
        {
          //Arrange
          string description01 = "Walk the dog";
          string description02 = "Wash the dishes";
          Item newItem1 = new Item(description01);
          Item newItem2 = new Item(description02);
          List<Item> newList = new List<Item> { newItem1, newItem2 };

          //Act
          List<Item> result = Item.GetAll();
          foreach (Item thisItem in result)
          {
            Console.WriteLine("Output: " + thisItem.GetDescription());
          }

          //Assert
          CollectionAssert.AreEqual(newList, result);
        }

        [TestMethod]
        public void Save_SavesToDatabase_ItemList()
        {
          //Arrange
          Item testItem = new Item("Mow the lawn");

          //Act
          int result = Item.GetAll().Count;

          //Assert
          Assert.AreEqual(0, result);
        }
      }
    }
