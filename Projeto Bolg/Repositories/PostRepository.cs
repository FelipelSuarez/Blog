using Microsoft.EntityFrameworkCore;
using Projeto_Bolg.Models;
using Projeto_Bolg.Repositories.Data;

namespace Projeto_Bolg.Repositories
{
	public class PostRepository : IPostRepository
    {
        private readonly BlogContext _context;

        public PostRepository(BlogContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Post>> GetAllUserPostsAsync(string userId)
        {
            var posts = await _context.Posts.Where(x => x.UserId == userId).ToListAsync();

            return posts;
        }

        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task<Post> GetAsync(int id)
        {
            return await _context.Posts.FindAsync(id);
        }

        public async Task<Post> CreateAsync(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return post;
        }

        public async Task<Post> UpdateAsync(Post post)
        {
            _context.Posts.Update(post);
            await _context.SaveChangesAsync();

            return post;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}