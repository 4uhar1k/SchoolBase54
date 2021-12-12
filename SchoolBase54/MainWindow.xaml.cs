using MySql.Data.MySqlClient;
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

namespace SchoolBase54
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        public void beginClick(object sender, EventArgs e)
        {
            ApplicationContext db = new ApplicationContext();
            string conn = "Server=vovas0rc.beget.tech;Database=vovas0rc_sbase54;Uid=vovas0rc_sbase54;Pwd=54School54;";
            MySqlConnection connection = new MySqlConnection(conn);
            connection.Open();
            /*foreach(Schoolar sch in db.schoolars)
            {
                MessageBox.Show($"{sch.name} {sch.surname}");
            }*/
            MessageBox.Show("uspex");
            connection.Close();
        }
    }
}
