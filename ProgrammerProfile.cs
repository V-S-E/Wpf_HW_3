using System;
using System.Collections.Generic;

namespace Wpf_HW_3
{
    internal class ProgrammerProfile
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public List<string> listOfProgrammingLanguages;
        public string Discription { get; set; }
        public string DateOfBirth { get; set; }
        public string EnglishLevel { get; set; }
        public string OS { get; set; }
        public int LevelOfPassionForProgramming { get; set; }

        public ProgrammerProfile()
        {
            SettingProperties();
        }

        /// <summary>
        /// инициализация свойст начальными значенниями
        /// </summary>
        public void SettingProperties()
        {
            Surname = string.Empty;
            Name = string.Empty;
            Patronymic = string.Empty;
            listOfProgrammingLanguages = new List<string>();
            Discription = string.Empty;
            DateOfBirth = string.Empty;
            EnglishLevel = string.Empty;
            OS = string.Empty;
            LevelOfPassionForProgramming = 0;
        }

        /// <summary>
        /// проверяет фамилию на пустую строку
        /// </summary>
        /// <returns>если фамилия не пустая строка возвращает true иначе false</returns>
        bool ValidSurname()
        {
            return Surname != string.Empty;
        }

        /// <summary>
        /// проверяет имя на пустую строку
        /// </summary>
        /// <returns>если имя не пустая строка возвращает true иначе false</returns>
        bool ValidName()
        {
            return Name != string.Empty;
        }

        /// <summary>
        /// проверяет отчество на пустую строку
        /// </summary>
        /// <returns>если отчество не пустая строка возвращает true иначе false</returns>
        bool ValidPatronymic()
        {
            return Patronymic != string.Empty;
        }

        /// <summary>
        /// проверяет количество записей в списке языков программирования
        /// </summary>
        /// <returns>если записей нет возвращает false иначе true</returns>
        bool ValidListOfProgrammingLanguages()
        {
            return listOfProgrammingLanguages.Count != 0;
        }

        /// <summary>
        /// проверяет вкладку "Расскажите о себе" на пустую строку
        /// </summary>
        /// <returns>если вкладка не пустая строка возвращает true иначе false</returns>
        bool ValidDiscription()
        {
            return Discription != string.Empty;
        }

        /// <summary>
        /// проверяет дату рождения на пустую строку
        /// </summary>
        /// <returns>если дата рождения не пустая строка возвращает true иначе false</returns>
        bool ValidDateOfBirth()
        {
            return DateOfBirth != string.Empty;
        }

        /// <summary>
        /// проверяет уровень английского на пустую строку
        /// </summary>
        /// <returns>если уровень английского не пустая строка возвращает true иначе false</returns>
        bool ValidEnglishLevel()
        {
            return EnglishLevel != string.Empty;
        }

        /// <summary>
        /// проверяет OS на пустую строку
        /// </summary>
        /// <returns>если OS не пустая строка возвращает true иначе false</returns>
        bool ValidOS()
        {
            return OS != string.Empty;
        }

        /// <summary>
        /// проверяет все данные
        /// </summary>
        /// <returns>если все данные прошли проверку возвращает true иначе false</returns>
        public bool ValidData()
        {
            if (ValidSurname() && ValidName() && ValidPatronymic()
                && ValidListOfProgrammingLanguages() && ValidDiscription()
                && ValidDateOfBirth() && ValidEnglishLevel() && ValidOS())
            {
                return true;
            }
            return false;
        }
    }
}
