using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Andromeda.MerchantManager.Data.Configurations;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Andromeda.MerchantManager.Data
{
    public class MongoContext : IMongoContext
    {
        private readonly IMongoDatabase _database;
        private readonly List<Func<Task>> _commands;

        public MongoContext(IOptions<MongoDbOptions> options)
        {
            var mongoDbSettings = options.Value;

            _commands = new List<Func<Task>>();

            var mongoClient = new MongoClient(mongoDbSettings.Connection);
            _database = mongoClient.GetDatabase(mongoDbSettings.DatabaseName);
        }

        public async Task<int> SaveChangesAsync()
        {
            var totalCommands = _commands.Count;

            foreach (var command in _commands)
            {
                await command();
            }

            _commands.Clear();
            return totalCommands;
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _database.GetCollection<T>(name);
        }

        public void AddCommand(Func<Task> func)
        {
            _commands.Add(func);
        }
    }
}