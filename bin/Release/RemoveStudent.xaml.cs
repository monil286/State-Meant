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
    /// Interaction logic for RemoveStudent.xaml
    /// </summary>
    /// 
    
    public partial class RemoveStudent : Window
    {
        private string fname;
        private string lname;
        private string S_ID;
        private OleDbConnection conn = new OleDbConnection();
        private int sid;

        public RemoveStudent()
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

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            FindFnameBtn.Visibility = System.Windows.Visibility.Hidden;
            FindFNameLbl.Visibility = System.Windows.Visibility.Hidden;
            FindLnameBtn.Visibility = System.Windows.Visibility.Hidden;
            FindLNameLbl.Visibility = System.Windows.Visibility.Hidden;
            Search.Visibility = System.Windows.Visibility.Hidden;
            Remove.Visibility = System.Windows.Visibility.Visible;
            Student_List.Visibility = System.Windows.Visibility.Visible;
            fname = this.FindFnameBtn.Text;
            lname = this.FindLnameBtn.Text;

            conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source = E:\StateMent\StateMent1.mdb";
            conn.Open();
            OleDbCommand cmd1 = new OleDbCommand("SELECT [First_Name], [Last_Name], [ID_Number] from User_Profile where First_Name = '" + fname + "' and Last_Name = '" + lname + "'", conn);
            try
            {
                cmd1.ExecuteNonQuery();
                OleDbDataAdapter dataadpat = new OleDbDataAdapter(cmd1);
                DataTable rp = new DataTable("User_Profile");
                dataadpat.Fill(rp);
                Student_List.ItemsSource = rp.DefaultView;
                dataadpat.Update(rp);
                conn.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show("Exception " + er.Message);
            }
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source = E:\StateMent\StateMent1.mdb";
            conn.Open();
            int rows = Student_List.SelectedIndex;
            MessageBox.Show("Selected Index : " + rows);
            try
            {
                Student_List.SelectionUnit = DataGridSelectionUnit.FullRow;
                DataGridCellInfo cel = Student_List.SelectedCells[2];
                S_ID = ((TextBlock)cel.Column.GetCellContent(cel.Item)).Text;
                sid = Convert.ToInt32(S_ID);
                OleDbCommand cmmd = new OleDbCommand("Delete [User_ID], [First_Name], [Last_Name], [User_Name], [Password], [Email_Address], [User_Role_ID], [ID_Number] from [User_Profile] where [ID_Number] = " + sid, conn);
                cmmd.ExecuteNonQuery();
                MessageBox.Show("Record of student is deleted");
            }
            catch (Exception er)
            {
                MessageBox.Show("Exception " + er.Message);
            }
        }
    }
}
