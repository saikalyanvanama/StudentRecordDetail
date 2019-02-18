using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Lib.Models;
using TestApp.Lib;

namespace TestApp
{

    public static class Program
    {
        //static Lib.Commons p = new Lib.Commons();

        
        static void Main(String[] args)
        {
            string weather = string.Empty;
            Task.Run(async () => {
                weather = await Helper.Helper.GetWeatherByCity("Bangalore,IN");
            }).Wait();

           
            Commons.Init();
            int choice;

            do
            {
                if (!string.IsNullOrEmpty(weather))
                   Console.WriteLine($"Temperature: {weather} Deg");
                Console.Write("\n-------------MENU--------------");
                Console.Write("\n 1. Add Students");
                Console.Write("\n 2. Display Students");
                Console.Write("\n 3. Update Student detals");
                Console.Write("\n 4. Serach Student details");
                Console.Write("\n 5. Highest Marks");
                Console.Write("\n 6. Exit");
                Console.Write("\n----------------------------");


                Console.Write("\n Enter your choice: ");
                var tempChoice = Console.ReadLine();
                if (int.TryParse(tempChoice, out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            AddStudent();
                            Console.WriteLine("\n Students Added!!");
                            break;
                        case 2:
                            Console.WriteLine("The Student Details are: ");
                            DisplayStudents();
                            break;
                        case 3:
                            UpdateStudent();
                            Console.WriteLine("\n Students updated!!");
                            break;
                        case 4:
                            SearchStudent();
                            break;
                        case 5:
                            HighestAverageStudent();
                            break;

                        case 6:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("\n Incorrect choice");
                            break;
                    }
                    Commons.SaveToFile();
                }
                     
                //hello test


            } while (choice != 6);



        }

        public static void HighestAverageStudent()
        {
            var sortedStudent = Commons.Students.Values.OrderByDescending(s => s.AvgMarks);
            var topThree = sortedStudent.Take(3);

            Console.WriteLine("\n----------Highest Average Students----------\n");
            foreach (var item in topThree)
            {
                DisPub(item);
                Console.WriteLine();
            }
            Console.WriteLine("\n---------------------------------------------\n");
        }


        public static void SearchStudent()
        {
            Console.Write("\n Enter the USN need to be searched :");
            var usnsearch = Console.ReadLine();
            if (!string.IsNullOrEmpty(usnsearch.Trim()))
            {
                usnsearch = usnsearch.ToLower();
                
                if (Commons.Students.ContainsKey(usnsearch))
                    DisPub(Commons.Students[usnsearch]);
                else
                    Console.WriteLine("\n USN has not been found!! ");
            }
            else
                Console.WriteLine("\n USN has not been found!! ");
        }


        public static void UpdateStudent()
        {
            Console.Write("\n Enter the USN which you want to be updated: ");
            var upUSN = Console.ReadLine();
            int choiceee;
            string yn;

            
            foreach (var item in Commons.Students.Values)
            {
                if (upUSN.ToLower().Equals(item.USN.ToLower()))
                {
                    do
                    {
                        Console.Write("\n----------Select which you want to update--------");
                        Console.Write("\n 1. FirstName \n 2. LastNAme \n 3. UpdateMarks \n 4. Quit Menu");
                        Console.Write("\n--------------------------------------------------");

                        Console.Write("\n enter your choiceee : ");
                        var tempChoice = Console.ReadLine();

                        if (int.TryParse(tempChoice, out choiceee))
                        {
                            switch (choiceee)
                            {
                                case 1:
                                    do
                                    {
                                        Console.Write(" Enter your First Name: ");
                                        item.FirstName = Console.ReadLine();
                                    } while (string.IsNullOrEmpty(item.FirstName.Trim()));
                                    Console.Write("\n Updated!!");

                                    Console.WriteLine("\n Do you want to exit (y/n): ");
                                    yn = Console.ReadLine();
                                    if ( yn.ToLower() == "y")
                                    {
                                        choiceee = 4;
                                    }
                                    else
                                    {
                                        continue;
                                    }

                                    break;

                                case 2:
                                    do
                                    {
                                        Console.Write(" Enter your Last Name: ");
                                        item.LastName = Console.ReadLine();
                                    } while (string.IsNullOrEmpty(item.LastName.Trim()));
                                    Console.Write("Updated!!");

                                    Console.WriteLine("\n Do you want to exit (y/n): ");
                                    yn = Console.ReadLine();
                                    if ( yn.ToLower() == "y")
                                    {
                                        choiceee = 4;
                                    }
                                    else
                                    {
                                        continue;
                                    }

                                    break;
                                    //Made some changes

                                case 3:
                                    ReadMarks(item);
                                    Console.Write("\n Updated!!");

                                    Console.WriteLine("\n Do you want to exit (y/n): ");
                                    yn = Console.ReadLine();
                                    if ( yn.ToLower() == "y")
                                    {
                                        choiceee = 4;
                                    }
                                    else
                                    {
                                        continue;
                                    }

                                    break;
                                case 4:
                                    choiceee = 4;
                                    break;
                               
                                default:
                                    Console.Write("\n Invalid input!!");
                                    break;

                            }
                        }

                    } while (choiceee != 4);

                }
                              
                  
            }
        }

        public static void AddStudent()
        {

            var s = new Student();
            Object obj = new Student();
            Object sobj = new Subject();
            
            Boolean flag = false; ;
            do
            {
                Console.Write("\n Enter your USN: ");
                s.USN = Console.ReadLine();
                if (Commons.Students.ContainsKey(s.USN.ToLower()))
                {
                    Console.Write("\n USN already exists.\n");

                }
                else
                {
                    Commons.Students.Add(s.USN.ToLower(), s);
                    flag = true;
                }

            } while (string.IsNullOrEmpty(s.USN.Trim()) || s.USN.Length != 10 || flag == false);

            do
            {
                Console.Write(" Enter your First Name: ");
                s.FirstName = Console.ReadLine();
            } while (string.IsNullOrEmpty(s.FirstName.Trim()));

            do
            {
                Console.Write(" Enter your Last Name: ");
                s.LastName = Console.ReadLine();
            } while (string.IsNullOrEmpty(s.LastName.Trim()));

            String extractString = s.USN.Substring(5, 2);
            Branch(s, extractString);

        }

        public static void ReadMarks(Student s)
        {
            int marks;
            bool flag = false;
            Console.WriteLine("\n Enter the obtained marks: ");
            for (int i = 0; i < s.Subjectlist.Count(); i++)
            {
                do
                {
                    Console.Write($">>>{s.Subjectlist.ElementAt(i).SubCode} - {s.Subjectlist.ElementAt(i).SubName} - Min:{s.Subjectlist.ElementAt(i).MinMarks} - Max:{s.Subjectlist.ElementAt(i).MaxMarks} : ");
                    var tempMarks = Console.ReadLine();

                    if(int.TryParse(tempMarks, out marks))
                    {
                        if (marks > 0 && marks <= s.Subjectlist.ElementAt(i).MaxMarks)
                        {
                            s.Subjectlist.ElementAt(i).MarksObtained = marks;
                            flag = true;
                        }
                        else
                        {
                            Console.WriteLine("\n Please enter the correct marks!!");
                            flag = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n Please enter the correct marks!!");
                        flag = false;
                    }
                
                } while (flag == false);

            }
        }

        public static void DisplayStudents()
        {
            Console.WriteLine("\n----------Display Students----------\n");
            foreach (var s in Commons.Students.Values)
            {
                DisPub(s);
                Console.WriteLine();
            }
            Console.WriteLine("\n-------------------------------------\n");

        }
        public static void Branch(Student s, string branch)
        {
            switch (branch.ToUpper())
            {
                case "IS":
                    s.Subjectlist.Add(Commons.AllSubs.Values.First());
                    s.Subjectlist.Add(Commons.AllSubs.Values.ElementAt(2));
                    s.Subjectlist.Add(Commons.AllSubs.Values.ElementAt(3));
                    break;
                case "CS":
                    s.Subjectlist.Add(Commons.AllSubs.Values.ElementAt(4));
                    s.Subjectlist.Add(Commons.AllSubs.Values.ElementAt(5));
                    s.Subjectlist.Add(Commons.AllSubs.Values.ElementAt(6));
                    break;
                case "EC":
                    s.Subjectlist.Add(Commons.AllSubs.Values.ElementAt(7));
                    s.Subjectlist.Add(Commons.AllSubs.Values.ElementAt(8));
                    s.Subjectlist.Add(Commons.AllSubs.Values.ElementAt(9));
                    break;
                case "ME":
                    s.Subjectlist.Add(Commons.AllSubs.Values.ElementAt(6));
                    s.Subjectlist.Add(Commons.AllSubs.Values.ElementAt(5));
                    s.Subjectlist.Add(Commons.AllSubs.Values.ElementAt(7));
                    break;
                default:
                    Console.Write("\n Invalid input");
                    break;

            }

        }

        public static void DisPub(Student s)
        {
            Console.WriteLine($" >>> {s.USN} - {s.FirstName}  {s.LastName} <<<");
            for (int i = 0; i < s.Subjectlist.Count(); i++)
            {
                Console.WriteLine($"-- {s.Subjectlist.ElementAt(i).SubCode} - {s.Subjectlist.ElementAt(i).SubName} - {s.Subjectlist.ElementAt(i).MarksObtained} ");
            }
            Console.Write($" The Total marks is: {s.TotalMarks} ");
            Console.Write($"\n The average marks is: {s.AvgMarks} \n");
        }


    }
}
