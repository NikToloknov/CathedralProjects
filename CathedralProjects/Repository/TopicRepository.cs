using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CathedralProjects.Models;
using CathedralProjects.Providers;
using MongoDB.Driver;

namespace CathedralProjects.Repository
{
    public class TopicRepository
    {
        private IMongoDatabase Database;
        private IMongoCollection<Topic> collection;  

        public TopicRepository(IMongoProvider provider)
        {
            Database = provider.database;
            collection = Database.GetCollection<Topic>("topic");
        }

        public void AddTopic(Topic topic)
        {
            collection.InsertOneAsync(topic);
        }

        public List<Topic> GetAllTopic(string groupId)
        {
            var filter = Builders<Topic>.Filter.Eq("Group", groupId);
            var result = collection.Find(filter);
            if (result.CountAsync().Result > 0)
            {
                return result.ToListAsync().Result.ToList();
            }
            return null;
        }
    }
}