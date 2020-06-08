﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using TodoApi.Exceptions;

namespace TodoApi.Controllers
{
    [Route("api/TodoItems")]
    [ApiController]
    public class TodoItemsController : ITodoItemsController
    {
        private readonly TodoContext _context;

        public TodoItemsController(TodoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<List<TodoItemDTO>> GetTodoItems()
        {
            return await _context.TodoItems
                .Select(x => ItemToDTO(x))
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<TodoItemDTO> GetTodoItem(long id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);

            return ItemToDTO(todoItem);
        }

        [HttpPut("{id}")]
        public async Task<TodoItemDTO> UpdateTodoItem(long id, TodoItemDTO todoItemDTO)

        {
            //if(id != todoItemDTO.Id)
            //{
            //    return BadRequest();
            //}

            var todoItem = await _context.TodoItems.FindAsync(id);
            //if (todoItem == null)
            //{
            //    return NotFound();
            //}

            todoItem.Name = todoItemDTO.Name;
            todoItem.IsComplete = todoItemDTO.IsComplete;

            try
            {
                await _context.SaveChangesAsync();

                return ItemToDTO(todoItem);
            }
            catch
            {
                throw new UnableToSaveItemException(todoItem.Name);
            }
        }

        [HttpPost]
        public async Task<TodoItemDTO> CreateTodoItem(TodoItemDTO todoItemDTO)
        {
            var todoItem = new TodoItem
            {
                IsComplete = todoItemDTO.IsComplete,
                Name = todoItemDTO.Name
            };

            _context.TodoItems.Add(todoItem);

            try
            {
                await _context.SaveChangesAsync();

                return ItemToDTO(todoItem);
            } catch
            {
                throw new UnableToSaveItemException(todoItem.Name);
            }    
        }

        [HttpDelete("{id}")]
        public async Task<TodoItemDTO> DeleteTodoItem(long id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);

            //if (todoItem == null)
            //{
            //    return NotFound();
            //}

            _context.TodoItems.Remove(todoItem);
            try
            {
                await _context.SaveChangesAsync();

                return ItemToDTO(todoItem);
            }
            catch
            {
                throw new UnableToSaveItemException(todoItem.Name);
            }
        }

        private static TodoItemDTO ItemToDTO(TodoItem todoItem) =>
            new TodoItemDTO
            {
                Id = todoItem.Id,
                Name = todoItem.Name,
                IsComplete = todoItem.IsComplete
            };
    }
}