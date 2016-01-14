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
using System.Data;
using System.Data.OleDb;


namespace Login
{
    /// <summary>
    /// Interaction logic for UserControl_score_screen.xaml
    /// </summary>
    public partial class UserControl_score_screen : UserControl
    {
        private OleDbConnection conn = new OleDbConnection();
        public UserControl_score_screen()
        {
            InitializeComponent();
            mapContent.Background = new ImageBrush(new BitmapImage(
                    new Uri("blank_state_map.jpg", UriKind.Relative)));
            Loaded += UserControl_score_screen_Loaded;
        }

        void UserControl_score_screen_Loaded(object sender, RoutedEventArgs e)
        {
            label_content.Content = "You Scored : " + (tally_value) + "/12";
            DateTime dn = DateTime.Now;
            //OleDbCommand cmmd = new OleDbCommand("INSERT INTO Game([Student_ID], [Game_Date], [Final_Score]) values ( " + Login_Page.usrName + "," + dn.ToString() + "," + tally_value + ")", conn);
            //cmmd.ExecuteNonQuery();
            conn.Close();


        }

        public int tally_value;
    }
}
