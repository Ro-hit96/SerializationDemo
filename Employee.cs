using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializationDemo
{
    [Serializable]//This informs to CLR that class can be serialized ==>Allow class serialized
    public class Employee
    {
        public int id { get; set; }
        public string Name { get; set; }
        public double salary { get; set; }
    }
}
