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
        public Task<List<TodoItemDTO>> GetTodoItems();

        public Task<TodoItemDTO> GetTodoItem(long id);

        public Task<TodoItemDTO> UpdateTodoItem(long id, TodoItemDTO todoItemDTO);

        public Task<TodoItemDTO> CreateTodoItem(TodoItemDTO todoItemDTO);

        public Task<TodoItemDTO> DeleteTodoItem(long id);
    }
}
