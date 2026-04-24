using BlazorApp1.Components.Pages.Todos;
using BlazorApp1.Data;
using BlazorApp1.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Services
{
    public class TodoService
    {
        private readonly AppDbContext _context;

        public TodoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Todo>?> GetAllAsync()
        {
            var todos = await _context.Todos
                .AsNoTracking()
                .Include(t => t.Author)
                .ToListAsync();
            return todos;
        }

        public async Task<Todo?> GetOneAsync(int id)
        {
            var todo = await _context.Todos
                .AsNoTracking()
                .Include(t => t.Author)
                .FirstOrDefaultAsync(t => t.TodoId == id);
            return todo;
        }

        public async Task<bool> CreateAsync(Todo todo)
        {
            if (todo == null) return false;
            _context.Todos.Add(todo);
            var res = await _context.SaveChangesAsync();
            return res >=1 ? true : false;
        }

        public async Task<bool> UpdateAsync(int id, Todo todo)
        {

            if (todo == null) return false;
            var existTodo = await _context.Todos.AsNoTracking().FirstOrDefaultAsync(t => t.TodoId == id);
            if (existTodo is null)
            {
                return false;
            }
            existTodo.Title = todo.Title;
            existTodo.AuthorId = todo.AuthorId;

            _context.Entry(existTodo).State = EntityState.Modified;
            var res = await _context.SaveChangesAsync();
            return res >= 1 ? true : false;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existTodo = await _context.Todos.AsNoTracking().FirstOrDefaultAsync(t => t.TodoId == id);
            if (existTodo is null)
            {
                return false;
            }
            _context.Remove(existTodo);
            _context.Entry(existTodo).State = EntityState.Deleted;
            var res = await _context.SaveChangesAsync();
            return res >= 1 ? true : false;
        }

        public async Task<List<Todo>?> GetTodosByName(string name)
        {
            var todos = await _context.Todos.AsNoTracking()
                .Where(t => EF.Functions.Like(t.Title,$"%{name}%"))
                .ToListAsync();
            return todos;
        }
    }
}
