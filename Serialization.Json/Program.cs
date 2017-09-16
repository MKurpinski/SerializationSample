using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Serialization.Xml;

namespace Serialization.Json
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
            using (var writer = new StreamWriter(File.Open("student.json", FileMode.Create)))
            {
                writer.Write(JsonConvert.SerializeObject(student));
            }

            student = null;

            using (var reader = new StreamReader(File.Open("student.json", FileMode.Open)))
            {
                student = JsonConvert.DeserializeObject<Student>(reader.ReadToEnd());
            }

            Console.WriteLine(student);

            Console.ReadKey();
        }
    }
}
