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

namespace Course {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {                
        Welcome welcome = new Welcome();
        Employee emp = new Employee();
        Chiefs chiefs;

        private string boss;    //начальник
        private string pos;     //должность   
        private int age;        //возраст

        public MainWindow()
        {
            InitializeComponent();            
            StartMode();         
        }        
        //Кнопка "Регистрация"
        private void btn_reg_Click(object sender, RoutedEventArgs e)
        {
            //Проверка на заполнение вссех полей для ввода данных
            CheckMode();
            //Если все поля были заполнены - то сотудник будет зарегестрирован
            if (!(second_name.Text == "" && fist_name.Text == ""
                && third_name.Text == "" && date.Text == ""
                && pos == "" && adress.Text =="")
                && Check(fist_name.Text) && Check(second_name.Text) 
                && Check(third_name.Text) && CheckBoss() && CheckAge(age))
            {
                chiefs = new Chiefs(second_name.Text + " " + fist_name.Text + " " + third_name.Text, position.SelectedIndex);
                if(position.SelectedIndex == 0 || position.SelectedIndex == 1)
                    lst_of_chiefs.Items.Add(second_name.Text + " " + fist_name.Text + " " + third_name.Text);
                welcome.Show();                                               
                emp.Add(pos, fist_name.Text, second_name.Text, third_name.Text, boss, age, adress.Text);                
                ClearMode();                                                         
            }
        }
        
        private void btn_employee_Click(object sender, RoutedEventArgs e)
        {            
            emp.Show();            
        }

        //Кнопка "Выход"
        Finish f = new Finish();
        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            f.Show();
        }
        //Выбор должности
        private void position_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (position.SelectedIndex == 0)            
                pos = "Руководитель отдела";                                               
            if (position.SelectedIndex == 1)
                pos = "Руководитель сектора";
            if (position.SelectedIndex == 2)
                pos = "Специалист";
            if (position.SelectedIndex == 1 || position.SelectedIndex == 2)
            {
                lst_of_chiefs.IsEnabled = true;
            }
            else
            {
                lst_of_chiefs.IsEnabled = false;
            }

            //if (position.SelectedIndex == 1 || position.SelectedIndex == 2)
            //{
            //    second_nameOfBoss.IsEnabled = true;
            //    fist_nameOfBoss.IsEnabled = true;
            //    third_nameOfBoss.IsEnabled = true;
            //}
            //else
            //{
            //    second_nameOfBoss.IsEnabled = false;
            //    fist_nameOfBoss.IsEnabled = false;
            //    third_nameOfBoss.IsEnabled = false;
            //}
        }

        private bool Check(string str)
        {
            char letter;            
            for (int i = 0; i < str.Length; i++)
            {
                letter = Convert.ToChar(str[i]);
                if ((int)letter < 1040 || (int)letter > 1103)
                {
                    return false;
                }
            }
            return true;
        }

        //Проверка на заполнение всех данных о начальнике
        private bool CheckBoss()
        {
            //if (fist_nameOfBoss.IsEnabled)
            //{
            //    //Фамилий
            //    if (second_nameOfBoss.Text == "")
            //    {
            //        second_nameOfBoss.BorderBrush = Brushes.Red;
            //        lb_snameOfBoss.Foreground = Brushes.Red;
            //        return false;
            //    }
            //    else
            //    {
            //        second_nameOfBoss.BorderBrush = Brushes.Green;
            //        lb_snameOfBoss.Foreground = Brushes.Green;                   
            //    }
            //    //Имя
            //    if (fist_nameOfBoss.Text == "")
            //    {
            //        fist_nameOfBoss.BorderBrush = Brushes.Red;
            //        lb_nameOfBoss.Foreground = Brushes.Red;
            //        return false;
            //    }
            //    else
            //    {
            //        fist_nameOfBoss.BorderBrush = Brushes.Green;
            //        lb_nameOfBoss.Foreground = Brushes.Green;                  
            //    }
            //    //Отчество
            //    if (third_nameOfBoss.Text == "")
            //    {
            //        third_nameOfBoss.BorderBrush = Brushes.Red;
            //        lb_thirdOfBoss.Foreground = Brushes.Red;
            //        return false;
            //    }
            //    else
            //    {
            //        third_nameOfBoss.BorderBrush = Brushes.Green;
            //        lb_thirdOfBoss.Foreground = Brushes.Green;                    
            //    }
            //boss = "Начальник: " + second_nameOfBoss.Text + " " + fist_nameOfBoss.Text + " " + third_nameOfBoss.Text; 
            //}
            //else
            //{
            //    boss = "";
            //    return true;
            //}
            if (lst_of_chiefs.SelectedIndex != -1)
                boss = "Начальник: " + lst_of_chiefs.SelectedItem.ToString();
            else boss = "";
            return true;
        }

        //Проверка сотрудника на возраст (разрешенный возраст от 18 до 70)
        private bool CheckAge(int age)
        {
            if (age < 18 || age > 70)           
                return false;            
            else
                return true;
        }

        private void exit(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                f.Show();            
        }

        private void ClearMode()
        {
            fist_name.Clear();
            second_name.Clear();
            third_name.Clear();
            position.Text = "";
            date.Text = "";
            adress.Clear();
            //second_nameOfBoss.Clear();
            //second_nameOfBoss.IsEnabled = false;
            //fist_nameOfBoss.Clear();
            //fist_nameOfBoss.IsEnabled = false;
            //third_nameOfBoss.Clear();
            //third_nameOfBoss.IsEnabled = false;
        }

        private void StartMode()
        {
            second_name.Focus();
            second_name.TabIndex = 0;
            fist_name.TabIndex = 1;
            third_name.TabIndex = 2;
            date.TabIndex = 4;
            adress.TabIndex = 5;
            position.TabIndex = 6;
            //second_nameOfBoss.TabIndex = 7;
            //fist_nameOfBoss.TabIndex = 8;
            //third_nameOfBoss.TabIndex = 9;
            btn_reg.TabIndex = 10;
            btn_employee.TabIndex = 11;
            btn_exit.TabIndex = 12;
        }

        private void CheckMode()
        {
            //Фамилия
            if (second_name.Text == "" || !Check(second_name.Text))
            {
                lb_sname.Foreground = Brushes.Red;
                second_name.BorderBrush = Brushes.Red;
            }
            else
            {
                lb_sname.Foreground = Brushes.Green;
                second_name.BorderBrush = Brushes.Green;
            }
            //Имя       
            if (fist_name.Text == "" || !Check(fist_name.Text))
            {
                fist_name.BorderBrush = Brushes.Red;
                lb_name.Foreground = Brushes.Red;
            }
            else
            {
                lb_name.Foreground = Brushes.Green;
                fist_name.BorderBrush = Brushes.Green;
            }
            //Отчество
            if (third_name.Text == "" || !Check(third_name.Text))
            {
                lb_third.Foreground = Brushes.Red;
                third_name.BorderBrush = Brushes.Red;
            }
            else
            {
                lb_third.Foreground = Brushes.Green;
                third_name.BorderBrush = Brushes.Green;
            }
            //Дата Рождения
            if (date.Text == "")
            {
                lb_date.Foreground = Brushes.Red;
                date.BorderBrush = Brushes.Red;
            }
            else
            {
                lb_date.Foreground = Brushes.Green;
                date.BorderBrush = Brushes.Green;
                string[] data = date.Text.Split('.');
                age = DateTime.Now.Year - Convert.ToInt32(data[2]);
            }
            if (!CheckAge(age))
            {
                lb_date.Foreground = Brushes.Red;
                date.BorderBrush = Brushes.Red;
            }
            else
            {
                lb_date.Foreground = Brushes.Green;
                date.BorderBrush = Brushes.Green;
            }
            if (adress.Text == "")
            {
                lb_adress.Foreground = Brushes.Red;
                adress.BorderBrush = Brushes.Red;
            }
            else
            {
                lb_adress.Foreground = Brushes.Green;
                adress.BorderBrush = Brushes.Green;
            }
            //Должность
            if (position.Text == "")
            {
                lb_position.Foreground = Brushes.Red;
                position.BorderBrush = Brushes.Red;
            }
            else
            {
                lb_position.Foreground = Brushes.Green;
                position.BorderBrush = Brushes.Green;
            }
        }


    }
}