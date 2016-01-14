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
using System.Data;
using System.Data.OleDb;

namespace Login
{
    /// <summary>
    /// Interaction logic for AddAdmin.xaml
    /// </summary>
    public partial class AddAdmin : Window
    {
        private OleDbConnection conn = new OleDbConnection();
        private string fname;
        private string lname;
        private string email;
        private string UID;
        private string password;
        private Int32 S_ID;
        
        public AddAdmin()
        {
            InitializeComponent();
        }

        private void Add_Admin_Click(object sender, RoutedEventArgs e)
        {
            conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source = StateMent1.mdb";
            conn.Open();
            fname = this.F_Name.Text;
            lname = this.L_Name.Text;
            email = this.Email.Text;
            UID = this.User_ID.Text;
            S_ID = Convert.ToInt32(this.Id_No.Text);
            password = this.Pass_1.Password;

            if (fname == "")
            {
                MessageBox.Show("Hey!! Enter your first name");
            }
            if (lname == "")
            {
                MessageBox.Show("Hey!! Enter your last name");
            }
            if (email == "")
            {
                MessageBox.Show("Hey!! Enter your Email ID");
            }
            if (UID == "")
            {
                MessageBox.Show("Hey!! Select your username");
            }
            if (password == "")
            {
                MessageBox.Show("Hey!! Choose a password");
            }
            if (S_ID == null)
            {
                MessageBox.Show("Hey! We need to make sure you haven't registered twice. Enter Your Student ID number");
            }
            OleDbCommand cmd = new OleDbCommand("SELECT COUNT(*) from User_Profile where ID_Number = " + S_ID, conn);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            if (i == 1)
            {
                MessageBox.Show("You are already registered with us. Please Login with that ID");
            }
            else
            {
                OleDbCommand cmmd = new OleDbCommand("INSERT INTO User_Profile([First_Name], [Last_Name], [User_Name], [Password] ,[Email_Address], [User_Role_ID], [ID_Number])" + " VALUES(@fname, @lname, @UID, @Password, @email, 1 , @S_ID)", conn);
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    //MessageBox.Show("Connection is Open");
                    cmmd.Parameters.Add("@fname", OleDbType.LongVarChar, 50).Value = fname;
                    cmmd.Parameters.Add("@lname", OleDbType.LongVarChar, 50).Value = lname;
                    cmmd.Parameters.Add("@UID", OleDbType.LongVarChar, 100).Value = UID;
                    cmmd.Parameters.Add("@password", OleDbType.LongVarChar, 50).Value = password;
                    cmmd.Parameters.Add("@email", OleDbType.LongVarChar, 100).Value = email;
                    cmmd.Parameters.Add("@S_ID", OleDbType.Integer, 10).Value = S_ID;
                    try
                    {
                        cmmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Data Entered");
                    }
                    catch (Exception er)
                    {
                        MessageBox.Show("Error " + er.Message + " Encountered");
                    }
                }
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AdminLogin ALog = new AdminLogin();
            ALog.ShowDialog();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
