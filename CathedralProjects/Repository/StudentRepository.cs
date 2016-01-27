using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CathedralProjects.Models;
using CathedralProjects.Providers;
using MongoDB.Driver;

namespace CathedralProjects.Repository
{
    public class StudentRepository
    {
        private IMongoDatabase Database;
        private IMongoCollection<Student> collection;  

        public StudentRepository(IMongoProvider provider)
        {
            Database = provider.database;
            collection = Database.GetCollection<Student>("student");
        }

        public void AddStudent(string id, string name, string surname, 
            string patronomic, string gropId, string email, string GitHub)
        {  
            collection.InsertOneAsync(new Student(id,name,surname, patronomic,gropId,email,GitHub));
        }

        public Student GetStudent(string id)
        {
            var query = Builders<Student>.Filter.Eq("_id", id);
            var result = collection.Find(query);
            if (result.CountAsync().Result > 0)
            {
                return result.ToListAsync().Result.First();
            }
            return null;
        }
    }
}