using System;
using Xunit;
using Moq;
using TodoApi.Controllers;
using TodoApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TodoItemsUnitTest
{
    public class TodoItemsControllerTest
    {
        [Fact]
        public void TestGetRoute_WhenTableEmpty()
        {
            // assemble

            var mockGet = new Mock<ITodoItemsController>();
        }
    }
}
