using AdapterLayer.Models;
using AdapterLayer.MongoDb;
using ApplicationLayer.Interfaces;
using MongoDB.Driver;

namespace AdapterLayer.Repository
{
    public class Repository : IRepository<UserModel>
    {
        private readonly MongoConnectionService _dbService;

        public Repository(MongoConnectionService dbService)
        {
            _dbService = dbService;
        }

        public async Task<IEnumerable<UserModel>> GetAllUsersAsync()
        {
            var collection = _dbService.Connect<UserModel>("users");
            var results = await collection.FindAsync(_ =>  true);
            return results.ToList();
        }

        public async Task AddUserAsync(UserModel user)
        {
            var collection = _dbService.Connect<UserModel>("users");
            await collection.InsertOneAsync(user);

        }
        
    }
}