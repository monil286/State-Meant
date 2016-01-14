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
using System.Data.OleDb;

namespace Login
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login_Page : Window
    {
        public static string usrName = string.Empty;
        public static string usrID = string.Empty;
        private OleDbConnection conn = new OleDbConnection();
        private string uname;
        private string pass;
        private string user;
        private string dbuname;
        private string dbpass;

        public Login_Page()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source = StateMent1.mdb";
            conn.Open();
            if ((User_Name.Text) == "")
            {
                MessageBox.Show("Please Enter your user name");
            }
            else
            {
                uname = this.User_Name.Text;
                usrName = uname;
            }
            if ((Password.Password) == "")
            {
                MessageBox.Show("Please Enter your password");
            }
            else
            {
                pass = this.Password.Password;
            }
            OleDbCommand cmmd = new OleDbCommand("SELECT [User_ID],[User_Name], [Password], [User_Role_ID] from User_Profile where User_Name = '" + uname + "' or Password = '" + pass + "'", conn);
            try
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    OleDbDataReader reader = cmmd.ExecuteReader();
                    if(reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            dbuname = reader[1].ToString();
                            dbpass = reader[2].ToString();
                            if (dbuname == uname && dbpass == pass)
                            {
                                Role_ID.Text = reader[3].ToString();
                                usrID = reader[0].ToString();
                                user = Role_ID.Text;
                            }
                            else if (dbuname == uname || dbpass == pass)
                            {
                                MessageBox.Show("Incorrect Username or Password. Please Try Again.");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Failed Login. Please Register yourself.");
                        this.Hide();
                        Registration reg = new Registration();
                        reg.ShowDialog();
                    }
                    if (user == "1")
                    {
                        this.Hide();
                        AdminLogin alog = new AdminLogin();
                        alog.ShowDialog();
                    }
                    else if (user == "2")
                    {
                        this.Hide();
                        TeacherLogin tlog = new TeacherLogin();
                        tlog.ShowDialog();
                    }
                    else if (user == "3")
                    {
                        this.Hide();
                        StudentLogin slog = new StudentLogin();
                        slog.ShowDialog();
                    }
                    reader.Close(); 
                }
            }
            catch (Exception er)
            {
                MessageBox.Show("Exception : " + er.Message);
            }
            
            conn.Close();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Registration reg = new Registration();
            reg.ShowDialog();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
