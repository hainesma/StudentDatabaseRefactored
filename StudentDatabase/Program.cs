using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Student_Database
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<string> studentNames = new List<string>() { "Mark Haines", "James Moulton", "Andrew Klima", "Tommy Waalkes", "Maggie Tamanini", "Jerome Brown", "Trent Nedbal", "Troy Vizina", "Kevin Jackson II", "Joshua Carolin", "Sean Boatman", "Kate Datema", "Maronda Anderson-Johnson"};
            //List<string> hometowns = new List<string>() { "Grand Rapids", "Toledo", "Grayslake", "Raleigh", "Montrose", "Milwaukee", "Rochester", "Indian River", "Detroit", "Northville", "Eaton Rapids", "Zeeland", "Unknown"};
            //List<string> favFoods = new List<string>() { "Cilantro", "Sushi", "Sushi", "Chicken Curry", "Movie Theatre Popcorn", "Italian Cuisine", "Tacos", "Broccoli", "Asian Cuisine", "Nalesniki", "Meat", "Pizza", "Unknown" };
            //List<string> homeStates = new List<string>() { "Michigan", "Ohio", "Illinois", "North Carolina", "Michigan", "Wisconsin", "Michigan", "Michigan", "Michigan", "Michigan", "Michigan", "Michigan", "Unknown"};

            // Create the list of Student objects
            List<Student> students = new List<Student>();
            students = LoadFromTxt("students.txt");

            //// Populate the object list from the 4 string lists above
            //for (int i = 0; i < studentNames.Count(); i++)
            //{
            //    Student a = new Student(studentNames[i], $"{hometowns[i]}, {homeStates[i]}", favFoods[i]);
            //    students.Add(a);
            //}
            //// Print out the properties of each Student object to make sure it worked
            //foreach (Student student in students)
            //{
            //    Console.WriteLine($"{student.Name}, {student.HomeTown}, {student.FavoriteFood}");
            //}

            Console.WriteLine("Welcome to the May 2021 C# Class!");
            Console.WriteLine($"There are {students.Count} members in this class. \n");


            
            SaveStudentsToTxt(students);

            bool again = true;
            while (again == true)
            {
                

                again = GetContinue();
            }

        }



        public static List<Student> LoadFromTxt(string filepath)
        {
            
            StreamReader reader = new StreamReader(filepath);
            string textFile = reader.ReadToEnd();
            reader.Close();
            string[] lines = textFile.Split('\n');
            List<Student> students = new List<Student>();
            
            foreach(string line in lines)
            {
                if(line.Trim().Length == 0 )
                {
                    continue;
                }
                else
                {
                    string[] splitLine = line.Split(',');
                    Student a = new Student(splitLine[0].Trim(), $"{splitLine[1].Trim()}, {splitLine[2].Trim()}", splitLine[3].Trim());
                    students.Add(a);
                }
            }
            return students;

        }

        public static void SaveStudentsToTxt(List<Student> students)
        {
            string filepath = "Students.txt";
            string toFile = "";
            StreamWriter writer = new StreamWriter(filepath);
            //Create string to save to file
            foreach(Student student in students)
            {
                string line = $"{student.Name}, {student.HomeTown}, {student.FavoriteFood} \n";
                toFile = string.Concat(toFile, line);
            }
            Console.WriteLine($"The following was saved to file: \n{toFile}");
            writer.Write(toFile);
            writer.Close();
        }

        // The original code for asking about students, put into a method
      
        //public static void LookUpStudents()
        //{
        //    string input = GetStudentNumber($"Which class member would you like to learn about? (Enter a number 0-12)");

        //    int index = int.Parse(input);

        //    string name = students[index].Name;

        //    bool badEntry = true;
        //    while (badEntry == true)
        //    {
        //        string input2 = GetUserInput($"Class member {input} is {name}.  What would you like to learn about them? HomeTown or FavoriteFood?");

        //        if (input2 == "hometown")
        //        {
        //            string ht = students[index].HomeTown;
        //            Console.WriteLine(ht);
        //            break;
        //        }
        //        else if (input2 == "favoritefood")
        //        {
        //            string ff = students[index].FavoriteFood;
        //            Console.WriteLine(ff);
        //            break;
        //        }
        //        else
        //        {
        //            string error = "That data does not exist.";

        //            Console.WriteLine(error);
        //        }
        //    }
        //}

        public static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine().ToLower().Trim();
            return input;
        }

        public static string GetUserInputName(string message)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine().ToLower().Trim();
            return input;

        }
        public static string GetStudentNumber(string message)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine().ToLower().Trim();
            int input1 = int.Parse(input);
            if (input1 > 13)
            {
                return "That member does not exist.";

            }
            else
            {
                return input;
            }
        }

        public static bool GetContinue()
        {
            Console.WriteLine();
            Console.WriteLine("Would you like to learn more? y/n");
            string answer = Console.ReadLine();
            if (answer.ToLower() == "y")
            {
                return true;
            }
            else if (answer.ToLower() == "n")
            {
                Console.WriteLine();
                Console.Write("Have a great day!");
                return false;
            }
            else
            {
                Console.WriteLine("I didn't understand your response, please try again...");
                return GetContinue();
            }
        }
    }
}




