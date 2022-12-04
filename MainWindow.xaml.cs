using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            profile= new ProgrammerProfile();
            yourForm = new YourForm();
        }

        private void btnPopup_Click(object sender, RoutedEventArgs e)
        {
            popUp_add.IsOpen = true;
        }

        /// <summary>
        /// нажатие на кнопку пройти анкетирование
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
        /// получаем фамилию из textBox_Surname анкеты и присваиваем значение свойству Surname класса ProgrammerProfile
        /// </summary>
        void GetSurname()
        {
            profile.Surname = textBox_Surname.Text;
        }

        /// <summary>
        /// записываем в textBlock_Surname YourForm значение из свойства Surname класса ProgrammerProfile
        /// </summary>
        void SetSurname()
        {
            yourForm.textBlock_Surname.Text = profile.Surname;
        }

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
