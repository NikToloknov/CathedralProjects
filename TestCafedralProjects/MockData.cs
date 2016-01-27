using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CathedralProjects.Models;
using CathedralProjects.Providers;
using CathedralProjects.Repository;
using NUnit.Framework;

namespace TestCafedralProjects
{
    [TestFixture]
    class MockData
    {
        private MongoProvider mongoProvider;
        private GroupRepository groupRepository;
        private SubjectRepository subjectRepository;
        private TopicRepository topicRepository;
        private TeacherRepository teacherRepository;

        [SetUp]
        public void SetUp()
        {
            mongoProvider = new MongoProvider("mongodb://localhost:27017", "Student");
            groupRepository = new GroupRepository(mongoProvider);
            subjectRepository = new SubjectRepository(mongoProvider);
            topicRepository = new TopicRepository(mongoProvider);
            teacherRepository = new TeacherRepository(mongoProvider);
        }

        [Test]
        public void AddGroup()
        {
            for (int i = 1; i < 5; i++)
            {
                groupRepository.AddGroup("ПИбд-41");   
            }
        }

        [Test]
        public void AddSubject()
        {
            Subject subject = new Subject();
            subject.ID = Guid.NewGuid();
            subject.Name = "РВИП";
            subject.Description = "Распределйнные вычисления и программы";
            subject.Exam = true;
            subject.Project = false;
            subjectRepository.AddSubject(subject);
        }

        [Test]
        public void AddTeacher()
        {
            Teacher teacher = new Teacher();
            teacher.ExternalId = Guid.NewGuid().ToString();
            teacher.Name = "Иван";
            teacher.Surname = "Иванов";
            teacher.Patronomic = "Иванович";
            teacher.Cathedral = "ИС";
            teacher.Email = "ivan.ivanov@gmail.com";

            teacherRepository.AddTeacher(teacher);
        }

        [Test]
        public void AddTopic()
        {
            //Topic topic = new Topic("d912c4ae-9115-4187-a46c-5894bfa0ddc8", "df1f8eba-ae68-433b-ac6a-77cd5db27c9e",
            //    "Разработка разработки разработчиков","Разарботать раазработанную разработку разработчиков",DateTime.Now.Ticks,"21007c99-aedc-4b43-a835-5d5ac271cd83");
            //Topic topic2 = new Topic("d912c4ae-9115-4187-a46c-5894bfa0ddc8", "df1f8eba-ae68-433b-ac6a-77cd5db27c9e",
            //    "Разработка разработки разработчиков", "Разарботать раазработанную разработку разработчиков", DateTime.Now.Ticks, "21007c99-aedc-4b43-a835-5d5ac271cd83");
            //topicRepository.AddTopic(topic);
            //topicRepository.AddTopic(topic2);
            var rez = topicRepository.GetAllTopic("df1f8eba-ae68-433b-ac6a-77cd5db27c9e");
        }

        [TearDown]
        public void TearDown()
        {

        }
    }
}
