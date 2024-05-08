using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIODemo
{
    // inform the class that this class need to be serialized 
    // allow for serialization 
    [Serializable] //attribute
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public double Salary { get; set; }
    }
}
