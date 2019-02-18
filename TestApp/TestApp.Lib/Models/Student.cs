using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Lib.Models
{
    public class Student
    {
        public string USN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<Subject> Subjectlist { get; set; }

        public double AvgMarks
        {
            get
            {
                return Subjectlist.Average(s => s.MarksObtained);
            }
        }

        public double TotalMarks
        {
            get
            {
                return Subjectlist.Sum(s => s.MarksObtained);
            }
        }

        public Student()
        {
            Subjectlist = new List<Subject>();
        }

    }



}
