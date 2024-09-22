using ExpensesApi.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesApi.Presentation.Controllers
{
    /// <summary>
    /// User Controller
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllUsers(CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllUserAsync(cancellationToken);
            return Ok(users);
        }

        /// <summary>
        /// Get the user by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(Guid id, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(id, cancellationToken);
            if (user == null)
                return NotFound();

            return Ok(user);
        }
    }
}
