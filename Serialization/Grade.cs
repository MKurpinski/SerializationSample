using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    [Serializable]
    public class Grade
    {
        public string Subject {
            get => _subject;
            set => _subject = value;
        }
        public double Mark { get; set; }
        public DateTime Date { get; set; }
        [NonSerialized]
        private string _subject;
        public override string ToString()
        {
            return $"Subject: {Subject} Grade: {Mark} Date: {Date}";
        }
    }
}
