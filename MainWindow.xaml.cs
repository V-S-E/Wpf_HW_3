using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Wpf_HW_3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ProgrammerProfile profile;
        YourForm yourForm;

        public MainWindow()
        {
            InitializeComponent();
            AgeLimit();
            profile = new ProgrammerProfile();
        }

        private void btnPopup_Click(object sender, RoutedEventArgs e)
        {
            popUp_add.IsOpen = true;
        }

        /// <summary>
        /// нажатие на кнопку - пройти анкетирование
        /// </summary>
        private void TakeSurvey_Click(object sender, RoutedEventArgs e)
        {
            GetSurname();
            GetName();
            GetPatronymic();
            GetProgrammingLanguages();
            GetDescription();
            GetDateOfBirth();
            if (ValidData())
            {
                yourForm = new YourForm();
                SetSurname();
                SetName();
                SetPatronymic();
                SetProgrammingLanguages();
                SetDiscription();
                SetDateOfBirth();
                yourForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        /// <summary>
        /// получает фамилию из textBox_Surname анкеты и присваивает значение свойству Surname класса ProgrammerProfile
        /// </summary>
        void GetSurname()
        {
            profile.Surname = textBox_Surname.Text;
        }

        /// <summary>
        /// записывает в textBlock_Surname YourForm значение из свойства Surname класса ProgrammerProfile
        /// </summary>
        void SetSurname()
        {
            yourForm.textBlock_Surname.Text = profile.Surname;
        }

        /// <summary>
        /// получает имя из textBox_Name анкеты и присваивает значение свойству Name класса ProgrammerProfile
        /// </summary>
        void GetName()
        {
            profile.Name = textBox_Name.Text;
        }

        /// <summary>
        /// записывает в textBlock_Name YourForm значение из свойства Name класса ProgrammerProfile
        /// </summary>
        void SetName()
        {
            yourForm.textBlock_Name.Text = profile.Name;
        }

        /// <summary>
        /// получает имя из textBox_Patronymic анкеты и присваивает значение свойству Name класса ProgrammerProfile
        /// </summary>
        void GetPatronymic()
        {
            profile.Patronymic = textBox_Patronymic.Text;
        }

        /// <summary>
        /// записывает в textBlock_Patronymic YourForm значение из свойства Patronymic класса ProgrammerProfile
        /// </summary>
        void SetPatronymic()
        {
            yourForm.textBlock_Patronymic.Text = profile.Patronymic;
        }

        /// <summary>
        /// получает из stackPanel_listOfProgrammingLanguages content из отмеченных checkBox и добавляет в List класса ProgrammerProfile
        /// </summary>
        void GetProgrammingLanguages()
        {
            foreach (CheckBox item in stackPanel_listOfProgrammingLanguages.Children.OfType<CheckBox>())
            {
                if (item.IsChecked == true)
                {
                    profile.listOfProgrammingLanguages.Add(item.Content.ToString());
                }
            }
        }

        /// <summary>
        /// записывает в textBlock_ProgrammingLanguages YourForm значение из listOfProgrammingLanguages класса ProgrammerProfile
        /// </summary>
        void SetProgrammingLanguages()
        {
            foreach (var item in profile.listOfProgrammingLanguages)
            {
                yourForm.textBlock_ProgrammingLanguages.Text += (item + "\n");
            }
            // удаляет последний "\n"
            if (yourForm.textBlock_ProgrammingLanguages.Text != string.Empty)
            {
                yourForm.textBlock_ProgrammingLanguages.Text = yourForm.textBlock_ProgrammingLanguages.Text.Substring(0, yourForm.textBlock_ProgrammingLanguages.Text.LastIndexOf("\n"));
            }
        }

        /// <summary>
        /// получает описание из textBox_Discription анкеты и присваивает значение свойству Discription класса ProgrammerProfile
        /// </summary>
        void GetDescription()
        {
            profile.Discription = textBox_Discription.Text;
        }

        /// <summary>
        /// записывает в textBlock_AboutMe YourForm значение из свойства Discription класса ProgrammerProfile
        /// </summary>
        void SetDiscription()
        {
            yourForm.textBlock_AboutMe.Text = profile.Discription;
        }

        /// <summary>
        /// получает дату из datePicker_DateOfBirth анкеты и присваивает значение свойству DateOfBirth класса ProgrammerProfile
        /// </summary>
        void GetDateOfBirth()
        {
            profile.DateOfBirth = datePicker_DateOfBirth.Text;
        }

        /// <summary>
        /// посчитывает количество полных лет и записывает в textBlock_FullYears YourForm
        /// </summary>
        void SetDateOfBirth()
        {
            yourForm.textBlock_FullYears.Text = profile.DateOfBirth;
        }

        /// <summary>
        /// проверяет данные из класса ProgrammerProfile
        /// </summary>
        /// <returns></returns>
        bool ValidData()
        {
            if (profile.ValidData())
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// добавляет данные из textBox_Add в listOfProgrammingLanguages класса ProgrammerProfile
        /// и закрывает popUp_add
        /// </summary>
        private void button_OK_Click(object sender, RoutedEventArgs e)
        {
            if (textBox_Add.Text != string.Empty)
            {
                profile.listOfProgrammingLanguages.Add(textBox_Add.Text);
            }
            textBox_Add.Text = string.Empty;
            popUp_add.IsOpen = false;
        }

        /// <summary>
        /// удаляет выбранные языки программирования и очищает listOfProgrammingLanguages класса ProgrammerProfile
        /// </summary>
        private void button_DeleteSelected_Click(object sender, RoutedEventArgs e)
        {
            foreach (CheckBox item in stackPanel_listOfProgrammingLanguages.Children.OfType<CheckBox>())
            {
                item.IsChecked = false;
            }
            profile.listOfProgrammingLanguages.Clear();
        }

        /// <summary>
        /// выводит количество используемых знаков в textBox_Discription в label_Discription
        /// </summary>
        private void textBox_Discription_TextChanged(object sender, TextChangedEventArgs e)
        {
            label_Discription.Content = $"{textBox_Discription.Text.Length}/500";
        }

        /// <summary>
        /// ограничивает выбор дат людям младше 18 лет
        /// </summary>
        void AgeLimit()
        {
            datePicker_DateOfBirth.DisplayDateEnd = DateTime.Now.AddYears(-18);
        }
    }
}
