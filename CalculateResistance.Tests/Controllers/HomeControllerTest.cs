using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculateResistance;
using CalculateResistance.Controllers;
using CalcuateResistance.Helpers;
using Newtonsoft.Json;
using Moq;

namespace CalculateResistance.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private object _calculator;

        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void Calculate()
        {

            var  mockResistor = new Moq.Mock<IOhmValueCalculator>();

            IOhmValueCalculator resistor = new Resistor();
            var result = resistor.CalculateOhmValue("Yellow", "Violet", "Red", "Gold");

            Assert.IsNotNull(result);
            Assert.AreEqual(result, 4935);

        }
    }
}
