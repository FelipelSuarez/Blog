using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Projeto_Bolg.Models;
using Projeto_Bolg.Repositories;
using Projeto_Bolg.Services;

namespace Projeto_Bolg.Controllers
{
    [ApiController]
	public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        private readonly INotificationService _notificationService;

        public PostController(INotificationService notificationService, IPostRepository postRepository)
        {
            _notificationService = notificationService;
            _postRepository = postRepository;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Post post)
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            post.UserId = userId;

            await _postRepository.CreateAsync(post);
            await _notificationService.SendNotificationAsync(new NotificationMessage { Message = "Nova Notificação" });
            return Ok(post);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePostAsync(int id, [FromBody] Post post)
        {
            var existingPost = await _postRepository.GetAsync(id);

            if (existingPost == null)
                return NotFound();

            if (existingPost.UserId != HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier))
                return Unauthorized();

            existingPost.Content = post.Content;

            await _postRepository.UpdateAsync(existingPost);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingPost = await _postRepository.GetAsync(id);

            if (existingPost == null)
                return NotFound();

            if (existingPost.UserId != HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier))
                return Unauthorized();

            await _postRepository.DeleteAsync(id);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var posts = await _postRepository.GetAllAsync();

            return Ok(posts);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAllUserPosts()
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var posts = await _postRepository.GetAllUserPostsAsync(userId);

            return Ok(posts);
        }
    }
}

