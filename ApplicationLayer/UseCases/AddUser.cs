using ApplicationLayer.Interfaces;

namespace ApplicationLayer.UseCases
{
    public class AddUser<T>
    {
        private readonly IRepository<T> _gexRepository;

        public AddUser(IRepository<T> repository)
        {
            _gexRepository = repository;
        }

        public async Task ExecuteAsync(T user)
        {
            await _gexRepository.AddUserAsync(user);
        }
    }
}
