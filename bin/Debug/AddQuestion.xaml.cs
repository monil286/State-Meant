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

namespace Login
{
    /// <summary>
    /// Interaction logic for AddQuestion.xaml
    /// </summary>
    public partial class AddQuestion : Window
    {
        public AddQuestion()
        {
            InitializeComponent();
        }

        private void Submit_Btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Question Added.");
        }

        private void Back_Btn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AdminLogin ALog = new AdminLogin();
            ALog.ShowDialog();
        }

        private void Cancel_Btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
