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
using System.IO;

namespace Course {
    /// <summary>
    /// Interaction logic for Finish.xaml
    /// </summary>
    public partial class Finish : Window {      
        public Finish()
        {
            InitializeComponent();
            btn_ok.Focus();
        }

        private void btn_no_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            File.Delete("Руководители отделов.txt");
            File.Delete("Руководители секторов.txt"); 
            Environment.Exit(0);
        }
    }
}