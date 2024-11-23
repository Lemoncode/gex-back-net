using ApplicationLayer.Interfaces;

namespace ApplicationLayer.UseCases
{
    public class GetUsers<T>
    {
        private readonly IRepository<T> _gexRepository;

        public GetUsers(IRepository<T> repository)
        {
            _gexRepository = repository;
        }

        public async Task<IEnumerable<T>> ExecuteAsync()
        {
            return await _gexRepository.GetAllUsersAsync();
        }

    }
}
