using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CathedralProjects.Models;
using CathedralProjects.Providers;
using MongoDB.Driver;

namespace CathedralProjects.Repository
{
    public class StageRepository
    {
        private IMongoDatabase Database;
        private readonly IMongoCollection<Stage> _collection;  

        public StageRepository(IMongoProvider provider)
        {
            Database = provider.database;
            _collection = Database.GetCollection<Stage>("stages");
        }

        public void AddStage(Stage stage)
        {
            _collection.InsertOneAsync(stage);
        }
        
        public void CompleteStage(string id)
        {
            var filter = Builders<Stage>.Filter.Eq("_id", id);
            var update = Builders<Stage>.Update.Set("State", true)
                    .CurrentDate("lastModified");
            var result = _collection.UpdateOneAsync(filter, update);
        }

        public void OpenStage(string id)
        {
            var filter = Builders<Stage>.Filter.Eq("_id", id);
            var update = Builders<Stage>.Update.Set("State", false)
                    .CurrentDate("lastModified");
            var result = _collection.UpdateOneAsync(filter, update);
        }
    }
}