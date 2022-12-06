using System.ComponentModel;
using System.Windows;

namespace Wpf_HW_3
{
    /// <summary>
    /// Логика взаимодействия для YourForm.xaml
    /// </summary>
    public partial class YourForm : Window
    {
        public YourForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// завершает работу приложения
        /// </summary>
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
