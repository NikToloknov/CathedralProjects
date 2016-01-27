using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CathedralProjects.Models;
using CathedralProjects.Providers;
using MongoDB.Driver;

namespace CathedralProjects.Repository
{
    public class SubjectRepository
    {
        private IMongoDatabase Database;
        private IMongoCollection<Subject> _collection;

        public SubjectRepository(IMongoProvider provider)
        {
            Database = provider.database;
            _collection = Database.GetCollection<Subject>("subjects");
        }

        public void AddSubject(Subject subject)
        {
            _collection.InsertOneAsync(subject);
        }
    }
}