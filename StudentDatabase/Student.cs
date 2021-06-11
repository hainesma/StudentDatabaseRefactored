using System;
using System.Collections.Generic;
using System.Text;

namespace Student_Database
{
    class Student
    {
        public string Name { get; set; }
        public string HomeTown { get; set; }
        public string FavoriteFood { get; set; }

        public Student (string name, string homeTown, string favoriteFood)
        {
            Name = name;
            HomeTown = homeTown;
            FavoriteFood = favoriteFood;
        }
    }
}
