using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIODemo
{
    [Serializable]
    public class Student
    {
        public int RollNo { get; set; }
        public string StdName { get; set; }

        public double stdPer { get; set; }
    }
}
