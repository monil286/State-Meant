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
    /// Interaction logic for AddClass.xaml
    /// </summary>
    public partial class AddClass : Window
    {
        private OleDbConnection conn = new OleDbConnection();
        private string name1;
        private string fname;
        private string lname;
        private string uid;
        private string cnt;

        public AddClass()
        {
            InitializeComponent();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source = StateMent1.mdb";
            conn.Open();
            try
            {
                OleDbCommand cmmd = new OleDbCommand("SELECT [User_ID], [First_Name], [Last_Name] from [User_Profile] where User_Role_ID = '2'", conn);
                OleDbDataReader reader = cmmd.ExecuteReader();
                while (reader.Read())
                {
                    
                    uid = reader[0].ToString();
                    OleDbCommand cmd1 = new OleDbCommand("Select [Class_ID] from [Class] where [Teacher_ID] = '" + uid + "'", conn);
                    OleDbDataReader reader1 = cmd1.ExecuteReader();
                    if (reader1.HasRows == false)
                    {
                        fname = reader[1].ToString();
                        lname = reader[2].ToString();
                        name1 = fname + " " + lname;
                        CTeacherCmb.Items.Add(name1);
                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show("Exception : " + er.Message);
            }
            conn.Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AdminLogin ALog = new AdminLogin();
            ALog.ShowDialog();
        }

        private void Add_Class_Click(object sender, RoutedEventArgs e)
        {
            conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source = StateMent1.mdb";
            conn.Open();
            string[] split = name1.Split(new char [] {' '});
            fname = Convert.ToString(split[0]);
            lname = Convert.ToString(split[1]);
            
            OleDbCommand cmmd = new OleDbCommand("Select [User_ID] from [User_Profile] where [First_Name] = '" + fname + "' AND [Last_Name] = '" + lname + "'", conn);
            try
            {
                OleDbDataReader reader = cmmd.ExecuteReader();
                while (reader.Read())
                {
                    uid = reader[0].ToString();
                }
                OleDbCommand cmd1 = new OleDbCommand("Insert into [Class]([Class_Name], [Teacher_ID]) values ('" + CNameTxt.Text + "','" + uid + "')", conn);
                cmd1.ExecuteNonQuery();
                MessageBox.Show("Class Created");
            }
            catch (Exception er)
            {
                MessageBox.Show("Exception " + er.Message);
            }
        }
    }
}
