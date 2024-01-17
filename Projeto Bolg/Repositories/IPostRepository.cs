using System.Threading.Tasks;
using Projeto_Bolg.Models;

namespace Projeto_Bolg.Repositories
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetAllUserPostsAsync(string userId);
        Task<IEnumerable<Post>> GetAllAsync();
        Task<Post> GetAsync(int id);
        Task<Post> CreateAsync(Post post);
        Task<Post> UpdateAsync(Post post);
        Task<bool> DeleteAsync(int id);
    }
}