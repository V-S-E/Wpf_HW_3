using System.Windows;

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
            yourForm = new YourForm();
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
            if (ValidData())
            {
                SetSurname();
                yourForm.Show();
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
