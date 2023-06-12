using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using ToDoWebAPI.BusinessClass;
using ToDoWebAPI.BusinessEntity;

namespace ToDoWebAPI.Controllers
{
    // TodoController.cs
    [ApiController]
    [Route("api/todos")]
    [Authorize]
    public class TodoController : ControllerBase
    {
        private readonly IToDoBC _toDoBC;

        public TodoController(IToDoBC todoBC)
        {
            _toDoBC = todoBC;
        }

        [HttpGet]
        public async Task<IActionResult> GetTodos()
        {
            var todos = await _toDoBC.GetTodos();
            return Ok(todos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoById(int id)
        {
            var todo = await _toDoBC.GetTodoById(id);
            if (todo == null)
                return NotFound();

            return Ok(todo);
        }

        [HttpPost]
        public async Task<IActionResult> AddTodo([FromBody] ToDoItem todo)
        {
            await _toDoBC.AddTodo(todo);
            return CreatedAtAction(nameof(GetTodoById), new { id = todo.Id }, todo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodo(int id, [FromBody] ToDoItem todo)
        {
            if (id != todo.Id)
                return BadRequest("Please enter correct id.");

            // var response = await _toDoBC.FindToDo(todo);

            // if(response == null)
            //     return BadRequest("Update failed. ToDo not exist.");

            await _toDoBC.UpdateTodo(todo);
            return Ok("Todo updated successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            await _toDoBC.DeleteTodo(id);
            return Ok("Deleted ToDo successfully.");
        }

        [HttpGet("filter")]
        public async Task<IActionResult> FilterTodosByStatus([FromBody] FilterToDo filter)
        {
            var todos = await _toDoBC.FilterTodosByStatus(filter.Status ?? string.Empty);
            return Ok(todos);
        }

        [HttpGet("sort")]
        public async Task<IActionResult> SortTodos(string sortBy)
        {
            var todos = await _toDoBC.SortTodos(sortBy);
            return Ok(todos);
        }

    }

}
