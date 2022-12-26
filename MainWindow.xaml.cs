using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Wpf_HW_3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 

    /*
     * Код оказался перегруженным. Какой ещё можно использовать способ?
     * 
     * 1) Для привязки значений, таких как количество введённых символов или процент слайдера
     * можно указать расширение Binding с атрибутом ElementName.
     * 
     * 2) Для обработки группы из RadioButton можно использовать цикл. Так как эти
     * элементы одного типа, удобно перебирать их и узнавать свойство IsChecked. Такую
     * обработку можно выполнить при нажатии на кнопку "Сформировать анкету". Такой 
     * способ предпочтителен при небольшом количестве RadioButton-ов (порядка 100).
     * Так же, для GroupBox, в котором находятся RadioButton-ы можно так же
     * указать один обработчик, который будет выцеплять Content и сохранять в буфер.
     * Общий обработчик на Checked можно привязать к каждой кнопке, или указать у GroupBox
     * прикрепляемое свойство ButtonBase.Click.
     * 
     * 3) Со списком ОС можно поступить аналогично - достаточно выцепить SelectedItem при нажатии
     * и разобрать при необходимости. Так же будет удобным использование атрибута Tag, который
     * может хранить ссылку на всё что угодно (есть у каждого элемента).
     * 
     * 4) Не совсем поняла, для чего нужна ссылка на форму YourForm.
     * 
     */

    public partial class MainWindow : Window
    {
        ProgrammerProfile profile;
        YourForm yourForm;
        string tempListBoxItemMore;

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
            GetEnglishLevel();
            GetOS();
            if (ValidData())
            {
                yourForm = new YourForm();
                SetSurname();
                SetName();
                SetPatronymic();
                SetProgrammingLanguages();
                SetDiscription();
                SetDateOfBirth();
                SetEnglishLevel();
                SetOS();
                SetPassionPercentage();
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
            if (tempListBoxItemMore != string.Empty)
            {
                profile.listOfProgrammingLanguages.Add(tempListBoxItemMore);
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
        /// подсчитывает количество полных лет и записывает в textBlock_FullYears YourForm
        /// записывает textBlock_DateOfBirth YourForm день рождения из свойства DateOfBirth класса ProgrammerProfile
        /// </summary>
        void SetDateOfBirth()
        {
            DateTime dateOfBirth = DateTime.Parse(profile.DateOfBirth);
            int age = DateTime.Today.Year - dateOfBirth.Year;
            if (dateOfBirth.AddYears(age) > DateTime.Today)
            {
                age--;
            }
            yourForm.textBlock_DateOfBirth.Text = profile.DateOfBirth;
            yourForm.textBlock_FullYears.Text = age.ToString();
        }

        /// <summary>
        /// получает из stackPanel_EnglishLevel content из отмеченной radioButton и присваивает значение свойству EnglishLevel класса ProgrammerProfile,
        /// запрещает дальнейшее изменение выбора
        /// </summary>
        void GetEnglishLevel()
        {
            foreach (RadioButton item in stackPanel_EnglishLevel.Children.OfType<RadioButton>())
            {
                if (item.IsChecked == true)
                {
                    profile.EnglishLevel = item.Content.ToString();
                    break;
                }
            }
            stackPanel_EnglishLevel.IsEnabled = false;
        }

        /// <summary>
        /// записывает в textBlock_EnglishLevel YourForm значение из свойства EnglishLevel класса ProgrammerProfile
        /// </summary>
        void SetEnglishLevel()
        {
            yourForm.textBlock_EnglishLevel.Text = profile.EnglishLevel;
        }

        /// <summary>
        /// получает из cвыбранного ComboBoxItem содержимое Tag и присваивает значение свойству OS класса ProgrammerProfile
        /// </summary>
        void GetOS()
        {
            foreach (ComboBoxItem item in comboBox_OS.Items.OfType<ComboBoxItem>())
            {
                if (item.IsSelected == true)
                {
                    profile.OS = item.Tag.ToString();
                }
            }
        }

        /// <summary>
        /// записывает в textBlock_PreferredOS YourForm значение из свойства OS класса ProgrammerProfile
        /// </summary>
        void SetOS()
        {
            yourForm.textBlock_PreferredOS.Text = profile.OS;
        }

        /// <summary>
        /// изменении значения слайдера. В данном случае будет изменяться выделение слайдера
        /// запись значения slider_PassionPercentage в свойство LevelOfPassionForProgramming класса ProgrammerProfile
        /// </summary>
        private void slider_PassionPercentage_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((Slider)sender).SelectionEnd = e.NewValue;
            profile.LevelOfPassionForProgramming = (int)e.NewValue;
        }

        /// <summary>
        /// записывает в textBlock_PassionPercentage YourForm значение из свойства LevelOfPassionForProgramming класса ProgrammerProfile
        /// </summary>
        void SetPassionPercentage()
        {
            yourForm.textBlock_PassionPercentage.Text = profile.LevelOfPassionForProgramming.ToString();
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
            tempListBoxItemMore = string.Empty;
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

        /// <summary>
        /// возникает при выборе listBoxItem_More
        /// </summary>
        private void listBoxItem_More_Selected(object sender, RoutedEventArgs e)
        {
            tempListBoxItemMore = textBlock_More.Text;
            expander_Additional.IsExpanded = false;
            listBoxItem_More.IsEnabled = false;
        }
    }
}
