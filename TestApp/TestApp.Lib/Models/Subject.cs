using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Lib.Models
{
    public class Subject
    {
        public string SubName { get; set; }
        public string SubCode { get; set; }
       // public int Submarks { get; set; }
        public int MaxMarks { get; set; }
        public int MinMarks { get; set; }
        public int MarksObtained { get; set; }
        
        public Subject() { }

        public Subject(Subject s)
        {
            this.MarksObtained = 0;
            //this.MarksObtained = s.MarksObtained ;
            this.MaxMarks = s.MaxMarks;
            this.MinMarks = s.MinMarks;
            this.SubCode = String.Copy(s.SubCode);
            this.SubName = String.Copy(s.SubName);
            
        }
    }
}
