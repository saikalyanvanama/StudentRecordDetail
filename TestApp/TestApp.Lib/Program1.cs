using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Lib.Models;

namespace TestApp.Lib
{
    public static class Commons
    {
        // Need to Set FilePath variable////
        public static string FilePath = @"D:\KalyanWork\TestApp\Data\TestAppData.json";
        public static Dictionary<string, Subject> AllSubs = new Dictionary<string, Subject>();
        public static Dictionary<string, Student> Students = new Dictionary<string, Student>();
        public static void SaveToFile()
        {
            var studentsJson = JsonConvert.SerializeObject(Students);
            File.WriteAllText(FilePath, studentsJson);
        }

        public static void ReadFromFile()
        {
            if (File.Exists(FilePath))
            {
                var studentsJson = File.ReadAllText(FilePath);
                Students = JsonConvert.DeserializeObject<Dictionary<string, Student>>(studentsJson);
            }
        }

        public static void Init()
        {
            ReadFromFile();
            Subject s1 = new Subject();
            s1.SubCode = "15CS61";
            s1.SubName = "Cryptography";
            s1.MaxMarks = 80;
            s1.MinMarks = 28;
            AllSubs.Add(s1.SubCode.ToLower(), s1);

            Subject s2 = new Subject();
            s2.SubCode = "15CS62";
            s2.SubName = "FileStructures";
            s2.MaxMarks = 80;
            s2.MinMarks = 28;
            AllSubs.Add(s2.SubCode.ToLower(), s2);

            Subject s3 = new Subject();
            s3.SubCode = "15CS63";
            s3.SubName = "SystemSoftware";
            s3.MaxMarks = 80;
            s3.MinMarks = 28;
            AllSubs.Add(s3.SubCode.ToLower(), s3);

            Subject s4 = new Subject();
            s4.SubCode = "15CS64";
            s4.SubName = "OperatingSystem";
            s4.MaxMarks = 80;
            s4.MinMarks = 28;
            AllSubs.Add(s4.SubCode.ToLower(), s4);

            Subject s5 = new Subject();
            s5.SubCode = "15CS65";
            s5.SubName = "SoftwareTesting";
            s5.MaxMarks = 80;
            s5.MinMarks = 28;
            AllSubs.Add(s5.SubCode.ToLower(), s5);

            Subject s6 = new Subject();
            s6.SubCode = "15CS66";
            s6.SubName = "Python";
            s6.MaxMarks = 80;
            s6.MinMarks = 28;
            AllSubs.Add(s6.SubCode.ToLower(), s6);

            Subject s7 = new Subject();
            s7.SubCode = "15CS67";
            s7.SubName = "SystemSoftwareLab";
            s7.MaxMarks = 80;
            s7.MinMarks = 28;
            AllSubs.Add(s7.SubCode.ToLower(), s7);

            Subject s8 = new Subject();
            s8.SubCode = "15CS68";
            s8.SubName = "FileStructureLab";
            s8.MaxMarks = 80;
            s8.MinMarks = 28;
            AllSubs.Add(s8.SubCode.ToLower(), s8);

            Subject s9 = new Subject();
            s9.SubCode = "15MAT11";
            s9.SubName = "Mathematics-1";
            s9.MaxMarks = 80;
            s9.MinMarks = 28;
            AllSubs.Add(s9.SubCode.ToLower(), s9);

            Subject s10 = new Subject();
            s10.SubCode = "15MAT21";
            s10.SubName = "Mathematics-2";
            s10.MaxMarks = 80;
            s10.MinMarks = 28;
            AllSubs.Add(s10.SubCode.ToLower(), s10);

        }
    }
}
