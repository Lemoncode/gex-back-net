using MongoDB.Driver;

namespace AdapterLayer.MongoDb
{
    public class MongoConnectionService
    {
        private readonly string ConnectionString;
        private readonly string DatabaseName;
        public MongoConnectionService() 
        {
            ConnectionString = Environment.GetEnvironmentVariable("MONGO_URL");
            if (ConnectionString == null) ConnectionString = "mongodb://localhost:27017";

            DatabaseName = Environment.GetEnvironmentVariable("MONGO_DB");
            if (DatabaseName == null) DatabaseName = "gex-api";
        }

        public IMongoCollection<T> Connect<T>(string collection)
        {
            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase(DatabaseName);
            return db.GetCollection<T>(collection);
        }

    }
}
