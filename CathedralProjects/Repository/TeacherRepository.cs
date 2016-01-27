using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CathedralProjects.Models;
using CathedralProjects.Providers;
using MongoDB.Driver;

namespace CathedralProjects.Repository
{
    public class TeacherRepository
    {
        private IMongoDatabase Database;
        private IMongoCollection<Teacher> _collection;

        public TeacherRepository(IMongoProvider provider)
        {
            Database = provider.database;
            _collection = Database.GetCollection<Teacher>("teacher");
        }


        public void AddTeacher(Teacher teacher)
        {
            _collection.InsertOneAsync(teacher);
        }
    }
}