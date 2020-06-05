using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using TodoApi.Exceptions;

namespace TodoApi.Controllers
{
    public interface ITodoItemsController
    {
        public Task<ActionResult<IEnumerable<TodoItemDTO>>> GetTodoItems();

        public Task<ActionResult<TodoItemDTO>> GetTodoItem(long id);

        public Task<ActionResult<TodoItemDTO>> UpdateTodoItem(long id, TodoItemDTO todoItemDTO);

        public Task<ActionResult<TodoItemDTO>> CreateTodoItem(TodoItemDTO todoItemDTO);

        public Task<ActionResult<TodoItemDTO>> DeleteTodoItem(long id);
    }
}
