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
using System.Data.OleDb;

namespace Login
{
    /// <summary>
    /// Interaction logic for AdminLogin.xaml
    /// </summary>
    public partial class AdminLogin : Window
    {
        private string fname;
        private string lname;
        private string uname = string.Empty;
        private string name;
        private OleDbConnection conn = new OleDbConnection();

        public AdminLogin()
        {
            InitializeComponent();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            uname = Login_Page.usrName;
            //MessageBox.Show("User " + uname + " Logged in");
            conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source = StateMent1.mdb";
            conn.Open();
            OleDbCommand cmmd = new OleDbCommand("SELECT [First_Name], [Last_Name] from [User_Profile] where User_Name = '" + uname + "'", conn);
            try
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    OleDbDataReader reader = cmmd.ExecuteReader();
                    while (reader.Read())
                    {
                        fname = reader[0].ToString();
                        lname = reader[1].ToString();
                    }
                    reader.Close();
                }
            }
            catch (Exception er)
            {
                MessageBox.Show("Exception : " + er.Message);
            }
            name = "Welcome " + fname + " " + lname + ".";
            WelcomeUser.Content = name;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddClass_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AddClass AC = new AddClass();
            AC.ShowDialog();
        }

        private void AddAdmin_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AddAdmin AAd = new AddAdmin();
            AAd.ShowDialog();

        }

        private void AddQuestion_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AddQuestion aq = new AddQuestion();
            aq.ShowDialog();
        }


    }
}
