using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_HW_3
{
    internal class ProgrammerProfile
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public List<string> listOfProgrammingLanguages;
        public string Discription { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string EnglishLevel { get; set; }
        public int LevelOfPassionForProgramming { get; set; }
        public string OS { get; set; }

        public ProgrammerProfile()
        {
            Surname = string.Empty;
            Name = string.Empty;
            Patronymic = string.Empty;
            listOfProgrammingLanguages = new List<string>();
            Discription = string.Empty;
            DateOfBirth = DateTime.MinValue;
            EnglishLevel = string.Empty;
            LevelOfPassionForProgramming = 0;
            OS = string.Empty;
        }

        public bool ValidData()
        {
            if (Surname != string.Empty)
            {
                return true;
            }
            return false;
        }
    }
}
