using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CathedralProjects.Models;
using CathedralProjects.Providers;
using MongoDB.Driver;

namespace CathedralProjects.Repository
{
    public class GroupRepository
    {
        private IMongoDatabase Database;
        private readonly IMongoCollection<Group> _collection;

        public GroupRepository(IMongoProvider provider)
        {
            Database = provider.database;
            _collection = Database.GetCollection<Group>("groups");
        }

        public void AddGroup(string name)
        {
            Group group = new Group(Guid.NewGuid().ToString(), name);
            _collection.InsertOneAsync(group);
        }
    }
}