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
            if (ValidData())
            {
                yourForm = new YourForm();
                SetSurname();
                SetName();
                SetPatronymic();
                SetProgrammingLanguages();
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

        void SetProgrammingLanguages()
        {
            foreach (var item in profile.listOfProgrammingLanguages)
            {
                yourForm.textBlock_ProgrammingLanguages.Text += item;
            }
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
    }
}
