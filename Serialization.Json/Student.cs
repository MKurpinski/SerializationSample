using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Serialization.Xml;

namespace Serialization.Json
{
    public class Student {
        [JsonProperty(PropertyName = "Index")]
        public string Id { get; set; }
        public string FirstName { get; set; }
        [JsonIgnore]
        public string LastName { get; set; }
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
