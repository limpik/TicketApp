using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BestBusWay.Domain.Repositories.OrderRepository.Interfaces;
using Moq;
using diploma.Controllers;
using BestBusWay.Domain.Entities;
using System.Web.Mvc;

namespace BestBusWay.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Save_Valid_Changes()
        {
            // Организация - создание имитированного хранилища данных
            Mock<IOrderRepository> mock = new Mock<IOrderRepository>();

            // Организация - создание контроллера
            AdminController controller = new AdminController(mock.Object);

            // Организация - создание объекта Game
            Order order = new Order { OrderId = 100 };

            // Действие - попытка сохранения товара
            ActionResult result = controller.Edit(order);

            // Утверждение - проверка того, что к хранилищу производится обращение
            mock.Verify(m => m.SaveOrder(order));

            // Утверждение - проверка типа результата метода
            Assert.IsNotInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Cannot_Save_Invalid_Changes()
        {
            // Организация - создание имитированного хранилища данных
            Mock<IOrderRepository> mock = new Mock<IOrderRepository>();

            // Организация - создание контроллера
            AdminController controller = new AdminController(mock.Object);

            // Организация - создание объекта Game
            Order order = new Order { OrderId = 100 };

            // Организация - добавление ошибки в состояние модели
            controller.ModelState.AddModelError("error", "error");

            // Действие - попытка сохранения товара
            ActionResult result = controller.Edit(order);

            // Утверждение - проверка того, что обращение к хранилищу НЕ производится 
            mock.Verify(m => m.SaveOrder(It.IsAny<Order>()), Times.Never());

            // Утверждение - проверка типа результата метода
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
    }
}
