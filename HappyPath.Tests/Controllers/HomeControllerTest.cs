using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HappyPath;
using HappyPath.Controllers;
using HappyPath.Service.Services;
using NSubstitute;
using HappyPath.Service.ViewModels;

namespace HappyPath.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        IPersonService _personService;
        HomeController _homeController;

        [TestInitialize]
        public void Setup()
        {
            _personService = Substitute.For<IPersonService>();
            _homeController = new HomeController(_personService);
        }

        [TestMethod]
        public void Index()
        {
            // Arrange
            _personService.GetPersonByName("Jason")
                .Returns(new PersonViewModel { FirstName = "Jason", LastName = "More" });

            // Act
            ViewResult result = _homeController.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Person: Jason More", result.ViewBag.Message);
        }

        [TestMethod]
        public void About()
        {
            // Arrange

            // Act
            ViewResult result = _homeController.About() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange

            // Act
            ViewResult result = _homeController.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
