using BlazorApp1.Data;
using BlazorApp1.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Services
{
    public class AuthorService
    {
        private readonly AppDbContext _context;

        public AuthorService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Author>?> GetAllAsync()
        {
            var authors = await _context.Authors
                 .AsNoTracking()
                 .Include(a => a.Todos)
                 .ToListAsync();

            return authors;
        }

        public async Task<Author?> GetOneAsync(int id)
        {
            var author = await _context.Authors
                .AsNoTracking()
                .Include(a => a.Todos)
                .Where(a => a.AuthorId == id)
                .FirstOrDefaultAsync();
            return author;
        }

        public async Task<Author?> CreateAsync(Author author)
        {
            if (author is null)
            {
                return default!;
            }
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task<bool> UpdateAsync(int id,Author author)
        {
            var existAuthor = await _context.Authors.AsNoTracking().FirstOrDefaultAsync(a => a.AuthorId == id);
            if (existAuthor is null)
            {
                return false;
            }

            existAuthor.Name = author.Name;
            _context.Entry(existAuthor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existAuthor = await _context.Authors.AsNoTracking().FirstOrDefaultAsync(a => a.AuthorId == id);
            if (existAuthor is null)
            {
                return false;
            }

            _context.Authors.Remove(existAuthor);
            _context.Entry(existAuthor).State = EntityState.Deleted;
            var res = await _context.SaveChangesAsync();
            return res >= 1 ? true : false;
        }
    }
}
