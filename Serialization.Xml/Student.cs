using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace Serialization.Xml
{
    public class Student { 
        [XmlElement("Index")]
        public string Id { get; set; }
        [XmlIgnore]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [XmlArray]
        public List<Grade> Grades { get; set; }
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
