using Microsoft.Win32;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для AddStudent.xaml
    /// </summary>
    public partial class AddStudent : Window
    {

        public AddStudent()
        {
            InitializeComponent();
           
            

        }
        public void MainMenu(object sender, EventArgs e)
        {
            this.Hide();
            MainWindow ma = new MainWindow();
            ma.Show();
        }

        public void ImageClick(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Image files (*.png, *.jpg)|*.png;*.jpg";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == true)
            {

                string path = openFileDialog1.FileName;
                imagepath.Content = path;
                imagepreview.Source = new BitmapImage(new Uri(path));
                //...
            }
        }

        public void ReadyClick(object sender, EventArgs e)
        {
            string FileName = imagepath.Content.ToString();
            byte[] ImageData;
            FileStream fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            ImageData = br.ReadBytes((int)fs.Length);
            br.Close();
            fs.Close();
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `schoolars` (`name`, `surname`, `fathername`, `grade`, `iin`, `image`) VALUES (@uN, @uS, @uF, @uG, @uI, @uP)", db.getConnection());
            command.Parameters.Add("@uN", MySqlDbType.VarChar).Value = NameTextBox.Text;
            command.Parameters.Add("@uS", MySqlDbType.VarChar).Value = SurnameTextBox.Text;
            command.Parameters.Add("@uF", MySqlDbType.VarChar).Value = OtceTextBox.Text;
            command.Parameters.Add("@uG", MySqlDbType.VarChar).Value = GradeTextBox.Text;
            command.Parameters.Add("@uI", MySqlDbType.VarChar).Value = IINTextBox.Text;
            command.Parameters.Add("@uP", MySqlDbType.Blob).Value = ImageData;
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
