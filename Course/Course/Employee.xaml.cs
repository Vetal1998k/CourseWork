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
using System.Windows.Shapes;

namespace Course {
    /// <summary>
    /// Interaction logic for Employee.xaml
    /// </summary>
    public partial class Employee : Window {                       
        public Employee()
        {
            InitializeComponent();                           
        }      

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            if (employee.SelectedIndex == -1)
                lbl_err.Visibility = Visibility.Visible;
            else
            {
                lbl_err.Visibility = Visibility.Hidden;
                employee.Items.RemoveAt(employee.SelectedIndex);
            }                      
        }

        //Метод,который выводит данные о сотруднике в список
        public void Add(string position, string firstName, string secondName, string thirdName, string boss, int age, string adress)
        {
            if(boss != "")
                employee.Items.Add("--Должность: " + position + "\n  ФИО: " + secondName + " " + firstName + " " + thirdName + "\n  Возраст: " + age + "\n  Адрес: " + adress + "\n  " + boss);
            else
                employee.Items.Add("--Должность: " + position + "\n  ФИО: " + secondName + " " + firstName + " " + thirdName + "\n  Возраст: " + age + "\n  Адрес: " + adress);            
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            lbl_err.Visibility = Visibility.Hidden;
            this.Hide();        
        }

        private void exit(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Hide();
        }       
    }
}