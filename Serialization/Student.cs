using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    [Serializable]
    public class Student : ISerializable
    {
        public Student()
        {
            
        }
        public Student(SerializationInfo info, StreamingContext context)
        {
            Id = info.GetString("Index");
            FirstName = info.GetString("FirstName");
            LastName = info.GetString("LastName");
            Grades =  (List<Grade>) info.GetValue("Grades", typeof(List<Grade>));
        }
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Grade> Grades { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Index", Id);
            info.AddValue("FirstName", FirstName);
            info.AddValue("LastName", LastName);
            info.AddValue("Grades", Grades);
        }

        public override string ToString()
        {
            var sb = new StringBuilder($"FirstName: {FirstName} LastName: {LastName} Index: {Id}\n");
            foreach (var grade in Grades)
            {
                sb.Append($"{grade}\n");
            }
            return sb.ToString();
        }
}
}
