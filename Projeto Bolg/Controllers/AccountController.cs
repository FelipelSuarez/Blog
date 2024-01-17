using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Projeto_Bolg.Models;
using Projeto_Bolg.Models.Requests;

namespace Projeto_Bolg.Controllers
{
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserStore<User> _userStore;

        public AccountController(IUserStore<User> userStore)
        {
            _userStore = userStore;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest model)
        {
            var user = new User(model.Username, model.Password);

            var result = await _userStore.CreateAsync(user, CancellationToken.None);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest model)
        {
            var user = await _userStore.FindByIdAsync(model.Username, CancellationToken.None);
            if (user != null)
            {
                var passwordHasher = new PasswordHasher<User>();
                var result = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, model.Password);
                if (result == PasswordVerificationResult.Success)
                    return Ok();
            } 

            return Unauthorized();
        }
    }
}