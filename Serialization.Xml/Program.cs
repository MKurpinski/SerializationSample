using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialization.Xml
{
    class Program
    {
        static void Main(string[] args)
        {
            var student = new Student()
            {
                FirstName = "John",
                LastName = "Smith",
                Id = "234567",
                Grades = new List<Grade>
                {
                    new Grade{Date = DateTime.UtcNow, Mark = 5, Subject = "Chemistry"},
                    new Grade{Date = DateTime.UtcNow.AddDays(-3), Mark = 2, Subject = "IT"},
                    new Grade{Date = DateTime.UtcNow, Mark = 5, Subject = "PE"}
                }
            };
            using (var stream = File.Open("student.xml", FileMode.Create))
            {
                var serializer = new XmlSerializer(typeof(Student));
                serializer.Serialize(stream, student);
            }

            student = null;
            using (var stream = File.Open("student.xml", FileMode.Open))
            {
                var serializer = new XmlSerializer(typeof(Student));
                student = (Student) serializer.Deserialize(stream);
            }

            Console.WriteLine(student);

            Console.ReadKey();
        }
    }
}
