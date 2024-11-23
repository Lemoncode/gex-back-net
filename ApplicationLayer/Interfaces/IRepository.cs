using DomainLayer;

namespace ApplicationLayer.Interfaces
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAllUsersAsync();
        Task AddUserAsync(T user);
    }
}
