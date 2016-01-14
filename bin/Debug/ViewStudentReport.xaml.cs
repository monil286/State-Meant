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
    /// Interaction logic for ViewStudentReport.xaml
    /// </summary>
    public partial class ViewStudentReport : Window
    {
        private string fname;
        private string lname;
        private string uid;
        private string sid;
        private OleDbConnection conn = new OleDbConnection();
        

        public ViewStudentReport()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            TeacherLogin tlog = new TeacherLogin();
            tlog.ShowDialog();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Back1_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            TeacherLogin tlog1 = new TeacherLogin();
            tlog1.ShowDialog();
        }

        private void Exit1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source = E:\StateMent\StateMent1.mdb";
            conn.Open();
            FNameLbl.Visibility = System.Windows.Visibility.Hidden;
            FNameTxt.Visibility = System.Windows.Visibility.Hidden;
            LNameLbl.Visibility = System.Windows.Visibility.Hidden;
            LNameTxt.Visibility = System.Windows.Visibility.Hidden;
            Search.Visibility = System.Windows.Visibility.Hidden;
            Back.Visibility = System.Windows.Visibility.Hidden;
            Exit.Visibility = System.Windows.Visibility.Hidden;
            StudList.Visibility = System.Windows.Visibility.Visible;
            Back1.Visibility = System.Windows.Visibility.Visible;
            Exit1.Visibility = System.Windows.Visibility.Visible;
            Show.Visibility = System.Windows.Visibility.Visible;
            fname = this.FNameTxt.Text;
            lname = this.LNameTxt.Text;
            OleDbCommand cmmd = new OleDbCommand("SELECT [User_ID], [First_Name], [Last_Name], [ID_Number] from [User_Profile] where First_Name = '" + fname + "' and Last_Name = '" + lname + "'", conn);
            try
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    cmmd.ExecuteNonQuery();
                    OleDbDataAdapter dataadpat = new OleDbDataAdapter(cmmd);
                    DataTable rp = new DataTable("User_Profile");
                    dataadpat.Fill(rp);
                    StudList.ItemsSource = rp.DefaultView;
                    dataadpat.Update(rp);
                    
                }
            }
            catch (Exception er)
            {
                MessageBox.Show("Exception : " + er.Message);
            }
            conn.Close();
        }

        private void Show_Click(object sender, RoutedEventArgs e)
        {
            StudList.SelectionUnit = DataGridSelectionUnit.FullRow;
            DataGridCellInfo cel = StudList.SelectedCells[0];
            uid = Convert.ToString(Convert.ToInt32(((TextBlock)cel.Column.GetCellContent(cel.Item)).Text));
            sid = Convert.ToString(uid);
            StudList.Visibility = System.Windows.Visibility.Hidden;
            StudScore.Visibility = System.Windows.Visibility.Visible;
            conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source = E:\StateMent\StateMent1.mdb";
            conn.Open();
            OleDbCommand cmd1 = new OleDbCommand("Select [Game_Date], [Final_Score], [Status] from [Game] where [Student_ID] = '" + sid + "'", conn);
            try
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    cmd1.ExecuteNonQuery();
                    OleDbDataAdapter dataadpat1 = new OleDbDataAdapter(cmd1);
                    DataTable rp1 = new DataTable("Game");
                    dataadpat1.Fill(rp1);
                    StudScore.ItemsSource = rp1.DefaultView;
                    dataadpat1.Update(rp1);
                }
            }
            catch (Exception er)
            {
                MessageBox.Show("Exception : " + er.Message);
            }
            conn.Close();
        }
    }
}
