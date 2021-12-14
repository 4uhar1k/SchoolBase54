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
using System.Windows.Shapes;

namespace SchoolBase54
{
    /// <summary>
    /// Логика взаимодействия для AddTeacher.xaml
    /// </summary>
    public partial class AddTeacher : Window
    {
        public AddTeacher()
        {
            InitializeComponent();
        }
        public void MainMenu(object sender, EventArgs e)
        {
            this.Hide();
            MainWindow ma = new MainWindow();
            ma.Show();
        }
        public void ReadyClick(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `workers` (`name`, `surname`, `fathername`, `category`, `iin`) VALUES (@uN, @uS, @uF, @uG, @uI)", db.getConnection());
            command.Parameters.Add("@uN", MySqlDbType.VarChar).Value = NameTextBox.Text;
            command.Parameters.Add("@uS", MySqlDbType.VarChar).Value = SurnameTextBox.Text;
            command.Parameters.Add("@uF", MySqlDbType.VarChar).Value = OtceTextBox.Text;
            command.Parameters.Add("@uG", MySqlDbType.VarChar).Value = CategoryTextBox.Text;
            command.Parameters.Add("@uI", MySqlDbType.VarChar).Value = IINTextBox.Text;
            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("uspex");
            }
            else
            {
                MessageBox.Show("JlOX!");
            }
            db.closeConnection();
        }
    }
}
