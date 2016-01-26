using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;

namespace CathedralProjects.Providers
{
    public interface IMongoProvider
    {
        IMongoDatabase database { get; set; }
    }

    public class MongoProvider : IMongoProvider
    {
        public IMongoDatabase database { get; set; }

        public MongoProvider(string connectionString, string dataBase)
        {
           MongoClient client = new MongoClient(connectionString);
           database = client.GetDatabase(dataBase);
        }
    }
}