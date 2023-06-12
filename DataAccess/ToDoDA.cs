using Microsoft.EntityFrameworkCore;
using ToDoWebAPI.BusinessEntity;
using ToDoWebAPI.DataAccess.Models;

namespace ToDoWebAPI.DataAccess
{
    public interface IToDoDA
    {
        Task<IEnumerable<ToDoItem>> GetTodos();
        Task<ToDoItem> GetTodoById(int id);
        Task AddTodo(ToDoItem todo);
        Task UpdateTodo(ToDoItem todo);
        Task DeleteTodo(int id);
        Task<IEnumerable<ToDoItem>> FilterTodosByStatus(string status);
        Task<IEnumerable<ToDoItem>> SortTodos(string sortBy);
        Task<ToDoItem?> FindToDo(ToDoItem todo);
    }

    public class ToDoDA : IToDoDA
    {
        private readonly ToDoDbContext _dbContext;

        public ToDoDA(ToDoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ToDoItem>> GetTodos()
        {
            return await _dbContext.ToDoItems.ToListAsync();
        }

        public async Task<ToDoItem> GetTodoById(int id)
        {
            return await _dbContext.ToDoItems.FindAsync(id);
        }

        public async Task AddTodo(ToDoItem todo)
        {
            _dbContext.ToDoItems.Add(todo);
            await _dbContext.SaveChangesAsync();

            //return CreatedAtAction("GetToDoItemModel", new { id = toDoItemModel.Id }, toDoItemModel);
        }

        public async Task UpdateTodo(ToDoItem todo)
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteTodo(int id)
        {
            var todo = await _dbContext.ToDoItems.FindAsync(id);
            _dbContext.ToDoItems.Remove(todo);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ToDoItem>> FilterTodosByStatus(string status)
        {
            return await _dbContext.ToDoItems.Where(t => t.Status == status).ToListAsync();
        }

        public async Task<IEnumerable<ToDoItem>> SortTodos(string sortBy)
        {
            IQueryable<ToDoItem> query = _dbContext.ToDoItems;

            switch (sortBy)
            {
                case "duedate":
                    query = query.OrderBy(t => t.DueDate);
                    break;
                case "status":
                    query = query.OrderBy(t => t.Status);
                    break;
                case "name":
                    query = query.OrderBy(t => t.Name);
                    break;
                default:
                    break;
            }

            return await query.ToListAsync();
        }

        public async Task<ToDoItem?> FindToDo(ToDoItem todo)
        {
            var response = await _dbContext.ToDoItems.FindAsync(todo);

            if (response != null)
                return response;

            return null;
        }
    }

}
