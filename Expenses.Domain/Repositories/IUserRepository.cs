using ExpensesApi.Domain.Entities;

namespace ExpensesApi.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<User>> GetAllUserAsync(CancellationToken cancellationToken);
        Task AddUserAsync(User user, CancellationToken cancellationToken);
        Task UpdateUserAsync(User user , CancellationToken cancellationToken);
        Task DeleteUserAsync(User user , CancellationToken cancellationToken);
    }
}
