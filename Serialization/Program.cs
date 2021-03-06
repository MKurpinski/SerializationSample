﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            var student = new Student
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

            using (var stream = File.Open("student.dat", FileMode.Create))
            {
                var bf = new BinaryFormatter();
                bf.Serialize(stream, student);
            }

            student = null;

            using (var stream = File.Open("student.dat", FileMode.Open))
            {
                var bf = new BinaryFormatter();
                student = (Student) bf.Deserialize(stream);
            }

            Console.WriteLine(student);
            
            Console.ReadKey();
        }
    }
}
