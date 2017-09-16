using System;

namespace Serialization.Xml
{
    public class Grade
    {
        public string Subject { get; set; }
        public double Mark { get; set; }
        public DateTime Date { get; set; }
        public override string ToString()
        {
            return $"Subject: {Subject} Grade: {Mark} Date: {Date}";
        }
    }
}
