using System;
using Xunit;
using Moq;
using TodoApi.Controllers;
using TodoApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TodoItemsUnitTest
{
    public class TodoItemsControllerTest
    {
        [Fact]
        public void TestGetTodoItems_WhenUserEmpty_ReturnEmptyList()
        {
            // assemble
            var mockTodoContext = new Mock<TodoContext>(new DbContextOptions<TodoContext>());
            var todoItemsController = new TodoItemsController(mockTodoContext.Object);
            // act
            var result = todoItemsController.GetTodoItems();
            // assert
            Assert.IsType<ActionResult<IEnumerable<TodoItemDTO>>>(result);
        }
    }
}
