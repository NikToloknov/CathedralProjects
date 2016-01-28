using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using CathedralProjects.Models;
using CathedralProjects.Providers;
using MongoDB.Driver;

namespace CathedralProjects.Repository
{
    public class ProjectRepository
    {
        private IMongoDatabase Database;
        private readonly IMongoCollection<Project> _collection;

        public ProjectRepository(IMongoProvider provider)
        {
            Database = provider.database;
            _collection = Database.GetCollection<Project>("projects");
        }

        public void addProject(string topicId, string studentId)
        {
            Project project = new Project();
            project.StudentId = studentId;
            project.ID = Guid.NewGuid();

            var collectionTopics = Database.GetCollection<Topic>("topic");
            var filter = Builders<Topic>.Filter.Eq("_id", topicId);
            var result = collectionTopics.Find(filter);
            if (result.CountAsync().Result > 0)
            {
                var topic = result.ToListAsync().Result.ToList().First();
                project.TeacherId = topic.TeacherId;
                project.Description = topic.Description;
                project.Lable = topic.Title;
                project.Subject = topic.SubjectId;
                project.TopicId = topic.ID;
                project.DateJoin = DateTime.Now.Ticks;
            }
            _collection.InsertOneAsync(project);
        }

        public void AddAssesment(string projectId, int assesment)
        {
            var filter = Builders<Project>.Filter.Eq("_id", projectId);
            var update = Builders<Project>.Update.Set("Assesment", assesment)
                    .CurrentDate("lastModified");
            var result = _collection.UpdateOneAsync(filter, update); 
        }

        public void AddCommanAssesmaent(string projectId, int commanAssesment)
        {
            var filter = Builders<Project>.Filter.Eq("_id", projectId);
            var update = Builders<Project>.Update.Set("commanAssesment", commanAssesment)
                    .CurrentDate("lastModified");
            var result = _collection.UpdateOneAsync(filter, update);
        }
    }
}