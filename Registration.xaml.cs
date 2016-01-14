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
using System.Text.RegularExpressions;

namespace Login
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Login_Page log = new Login_Page();
        public Registration()
        {
            InitializeComponent();
        }

        
        private OleDbConnection conn1 = new OleDbConnection();
        private string fname;
        private string lname;
        private string email;
        private string UID;
        private string password;
        private string u_role;
        private string pass122;
        private Int32 S_ID;
        private string class_ID;
        private int flag = 0;

        private void reg_Click(object sender, RoutedEventArgs e)
        {
            flag = 0;
            conn1.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source = StateMent1.mdb";
            conn1.Open();
            if (conn1.State == System.Data.ConnectionState.Open)
            {
                //MessageBox.Show("Connected To DataBase");
            }
            else
            {
                MessageBox.Show("Cant connect to Database");
            }
            fname = this.F_Name.Text;
            lname = this.L_Name.Text;
            email = this.Email.Text;
            UID = this.User_ID.Text;
            S_ID = Convert.ToInt32(this.Id_No.Text);
            if((Regex.IsMatch(email, @"^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$")) == false)
            {
                MessageBox.Show(email + " is not a valid email address. Please enter a valid email address");
                flag = 1;
            }
            if (role.SelectedIndex == 0)
            {
                class_ID = class_select.Text;
            }
            if ((this.Pass_1.Password) == (this.Pass_2.Password))
            {
                password = this.Pass_1.Password;
                pass122 = password;
            }
            else
            {
                MessageBox.Show("The two passwords do not match. Please renter passowrds");
                flag = 1;
            }
            if (role.SelectedIndex == 0)
            {
                u_role = "3";
            }
            else if (role.SelectedIndex == 1)
            {
                u_role = "2";
            }
            if (fname == "")
            {
                MessageBox.Show("Hey!! Enter your first name");
                flag = 1;
            }
            if (lname == "")
            {
                MessageBox.Show("Hey!! Enter your last name");
                flag = 1;
            }
            if (email == "")
            {
                MessageBox.Show("Hey!! Enter your Email ID");
                flag = 1;
            }
            if (UID == "")
            {
                flag = 1;
                MessageBox.Show("Hey!! Select your username");
            }
            if (password == "")
            {
                flag = 1;
                MessageBox.Show("Hey!! Choose a password");
            }
            if (u_role == "")
            {
                flag = 1;
                MessageBox.Show("We Dont know yet whether you are a teacher or a student!! Please Tell us");
            }
            if ((Convert.ToString(S_ID)) == null)
            {
                flag = 1;
                MessageBox.Show("Hey! We need to make sure you haven't registered twice. Enter Your Student ID number");
            }
            if (flag == 0)
            {
                OleDbCommand cmd = new OleDbCommand("SELECT COUNT(*) from User_Profile where ID_Number = " + S_ID, conn1);
                int i = Convert.ToInt32(cmd.ExecuteScalar());
                if (i == 1)
                {
                    MessageBox.Show("You are already registered with us. Please Login with that ID");
                }
                else
                {
                    OleDbCommand cmmd = new OleDbCommand("INSERT INTO User_Profile([First_Name], [Last_Name], [User_Name], [Password] ,[Email_Address], [User_Role_ID], [ID_Number])" + " VALUES(@fname, @lname, @UID, @Password, @email, @u_role, @S_ID)", conn1);
                    if (conn1.State == System.Data.ConnectionState.Open)
                    {
                        //MessageBox.Show("Connection is Open");
                        cmmd.Parameters.Add("@fname", OleDbType.LongVarChar, 50).Value = fname;
                        cmmd.Parameters.Add("@lname", OleDbType.LongVarChar, 50).Value = lname;
                        cmmd.Parameters.Add("@UID", OleDbType.LongVarChar, 100).Value = UID;
                        cmmd.Parameters.Add("@password", OleDbType.LongVarChar, 50).Value = pass122;
                        cmmd.Parameters.Add("@email", OleDbType.LongVarChar, 100).Value = email;
                        cmmd.Parameters.Add("@u_role", OleDbType.LongVarChar, 1).Value = u_role;
                        cmmd.Parameters.Add("@S_ID", OleDbType.Integer, 10).Value = S_ID;
                        try
                        {
                            cmmd.ExecuteNonQuery();
                            conn1.Close();
                            MessageBox.Show("Data Entered");
                            Login_Page.usrName = UID;
                        }
                        catch (Exception er)
                        {
                            MessageBox.Show("Error " + er.Message + " Encountered");
                        }
                        if (u_role == "3")
                        {
                            this.Hide();
                            StudentLogin slog = new StudentLogin();
                            slog.ShowDialog();
                        }
                        if (u_role == "2")
                        {
                            this.Hide();
                            TeacherLogin tlog = new TeacherLogin();
                            tlog.ShowDialog();
                        }
                    }
                }
            }
            else
            {
                conn1.Close();
            }
        }

        private void role_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (role.SelectedIndex == 0)
            {
                class_select.Visibility = Visibility.Visible;
                Select.Visibility = Visibility.Visible;
            }
            else if (role.SelectedIndex == 1)
            {
                class_select.Visibility = Visibility.Hidden;
                Select.Visibility = Visibility.Hidden;
            }
        }


        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Login_Page log1 = new Login_Page();
            log1.ShowDialog();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
