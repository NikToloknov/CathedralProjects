using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CathedralProjects.Providers;
using CathedralProjects.Repository;
using NUnit.Framework;

namespace TestCafedralProjects
{
    [TestFixture]
    class TestStudentRepository
    {
        private StudentRepository studentRepository;
        private string id;
        [SetUp]
        public void SetUp()
        {
            studentRepository = new StudentRepository(new MongoProvider("mongodb://localhost:27017", "Student"));
            id = "0197ca8e-564b-4aa5-ba28-039771045dec";
        }

        [Test]
        public void GetStudent_Real_Success()
        {
            var result = studentRepository.GetStudent(id);
            Assert.That("Test", Is.EqualTo(result.Name));
        }

        [TearDown]
        public void TearDown()
        {

        }
    }
}
