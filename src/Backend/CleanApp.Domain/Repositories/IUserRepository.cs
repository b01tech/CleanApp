using CleanApp.Domain.Entities;

namespace CleanApp.Domain.Repositories;
public interface IUserRepository
{
    public Task Add(User user);
    public Task<bool> ExistsActiveUserWithEmail(string email);
}
