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
using System.Data;

namespace Login
{
    /// <summary>
    /// Interaction logic for StudentPreviousScores.xaml
    /// </summary>
    public partial class StudentPreviousScores : Window
    {
        private string fname;
        private string lname;
        private string uname = string.Empty;
        private string UID = string.Empty;
        private string name;
        private int userID;
        private OleDbConnection conn = new OleDbConnection();

        public StudentPreviousScores()
        {
            InitializeComponent();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            uname = Login_Page.usrName;
            UID = Login_Page.usrID;
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
            name = fname + " " + lname + "'s Score Report : ";
            WelcomeUser.Content = name;
            OleDbCommand cmd1 = new OleDbCommand("SELECT [Game_Date], [Final_Score] from Game where Student_ID = '" + UID + "'", conn);
            try
            {
                cmd1.ExecuteNonQuery();
                OleDbDataAdapter dataadpat = new OleDbDataAdapter(cmd1);
                DataTable rp = new DataTable("Game");
                dataadpat.Fill(rp);
                Report.ItemsSource = rp.DefaultView;
                dataadpat.Update(rp);

                conn.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show("Exception " + er.Message);
            }
            
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            StudentLogin slog = new StudentLogin();
            slog.ShowDialog();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
