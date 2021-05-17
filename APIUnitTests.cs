using FakeItEasy;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SLB.Controllers;
using SLB.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace SLB.UnitTests
{
    //[TestClass]
    public class ByCustomCatNameControllerTests
    {
        
        [Fact]
        public void GetCustomer_Returns_The_Correct_Customer_By_Category_Name()
        {
            var mock = new Mock<ILogger<ByCustomCatNameController>>();
            ILogger<ByCustomCatNameController> logger = mock.Object;
            var apiController = new ByCustomCatNameController(logger);
            var dataStore = GetTestProducts();

            // Act
            List<Customer> result = apiController.Get(dataStore[0].CustomerCategoryName);

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(dataStore[0].CustomerCategoryName, result[0].CustomerCategoryName);
  
        }

        [Fact]
        public void GetCustomer_Returns_NOT_NULL_Value_For_Customer_By_Category_Name()
        {
            // Arrange
            var mock = new Mock<ILogger<ByCustomCatNameController>>();
            ILogger<ByCustomCatNameController> logger = mock.Object;
            var apiController = new ByCustomCatNameController(logger);
            var dataStore = GetTestProducts();

            // Act
            List<Customer> result = apiController.Get("Incorrect_CustomerCategoryName") as List<Customer>;

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(result);
        }

        [Fact]
        public void GetCustomer_Returns_INCORRECT_Value_For_Customer_By_Category_Name()
        {
            // Arrange
            var mock = new Mock<ILogger<ByCustomCatNameController>>();
            ILogger<ByCustomCatNameController> logger = mock.Object;
            var apiController = new ByCustomCatNameController(logger);
            var dataStore = GetTestProducts();

            // Act
            List<Customer> result = apiController.Get("Incorrect_CustomerCategoryName") as List<Customer>;

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreNotEqual("Incorrect_CustomerCategoryName", result);
        }

        private List<Customer> GetTestProducts()
        {
            var testProducts = new List<Customer>();
            testProducts.Add(new Customer
            {
                CustomerId = 1,
                CustomerName = "Tailspin Toys(Head Office)",
                CustomerCategoryName = "Novelty Shop",
                PrimaryContact = "Waldemar Fisar",
                AlternateContact = "Laimonis Berzins",
                PhoneNumber = "(308) 555-0100",
                FaxNumber = "(308) 555-0101",
                BuyingGroupName = "Tailspin Toys",
                WebsiteUrl = "http://www.tailspintoys.com",
                DeliveryMethod = "Delivery Van",
                CityName = "Lisco",
                DeliveryRun = "",
                RunPosition = ""
            });
            testProducts.Add(new Customer
            {
                CustomerId = 2,
                CustomerName = "Tailspin Toys(Head Office) 2",
                CustomerCategoryName = "Novelty Shop",
                PrimaryContact = "Waldemar",
                AlternateContact = "Laimonis",
                PhoneNumber = "(308) 555-0101",
                FaxNumber = "(308) 555-0102",
                BuyingGroupName = "Tailspin Toys",
                WebsiteUrl = "http://www.tailspintoys.com",
                DeliveryMethod = "Delivery Van",
                CityName = "Sylvanite",
                DeliveryRun = "",
                RunPosition = ""
            });
            testProducts.Add(new Customer
            {
                CustomerId = 3,
                CustomerName = "Tailspin Toys(Head Office) 3",
                CustomerCategoryName = "Novelty Shop",
                PrimaryContact = "Fisar",
                AlternateContact = "Berzins",
                PhoneNumber = "(308) 555-0102",
                FaxNumber = "(308) 555-0103",
                BuyingGroupName = "Tailspin Toys",
                WebsiteUrl = "http://www.tailspintoys.com",
                DeliveryMethod = "Delivery Van",
                CityName = "Gasport",
                DeliveryRun = "",
                RunPosition = ""
            });

            return testProducts;
        }
    }
}
