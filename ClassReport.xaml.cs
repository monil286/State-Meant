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
    /// Interaction logic for ClassReport.xaml
    /// </summary>
    public partial class ClassReport : Window
    {
        private OleDbConnection conn = new OleDbConnection();
        private string teachName;
        private string teachId;
        private Int32 TID;
        private string SID;
        public ClassReport()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            teachName = Login_Page.usrName;
            conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source = StateMent1.mdb";
            conn.Open();
            OleDbCommand cmmd = new OleDbCommand("SELECT [User_ID] from [User_Profile] where [User_Name] = '" + teachName + "'", conn);
            OleDbDataReader reader = cmmd.ExecuteReader();
            if (reader.HasRows == true)
            {
                while (reader.Read())
                {
                    teachId = reader[0].ToString();
                }
            }
            TID = Convert.ToInt32(teachId);
            OleDbCommand cmd1 = new OleDbCommand("SELECT [Student_User_ID] from [Class_Student_Teacher_Map] where [Teacher_User_ID] = " + TID , conn);
            OleDbDataReader reader1 = cmd1.ExecuteReader();
            if (reader1.HasRows == true)
            {
                while (reader1.Read())
                {
                    SID = reader1[0].ToString();
                    OleDbCommand cmd2 = new OleDbCommand("SELECT [Student_ID], [Game_Date], [Final_Score], [Status] from [Game] where [Student_ID] = '" + SID + "'", conn);
                    cmd2.ExecuteNonQuery();
                    OleDbDataAdapter dataadpat1 = new OleDbDataAdapter(cmd2);
                    DataTable rp1 = new DataTable("Game");
                    dataadpat1.Fill(rp1);
                    report.ItemsSource = rp1.DefaultView;
                    dataadpat1.Update(rp1);
                }
            }
            conn.Close();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            TeacherLogin tlog = new TeacherLogin();
            tlog.ShowDialog();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
