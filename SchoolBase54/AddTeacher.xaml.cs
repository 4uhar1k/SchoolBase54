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
    /// Логика взаимодействия для AddTeacher.xaml
    /// </summary>
    public partial class AddTeacher : Window
    {
        List<string> rewardname = new List<string>();
        List<string> rewardyear = new List<string>();
        List<BitmapImage> rewardimage = new List<BitmapImage>();
        public AddTeacher()
        {
            InitializeComponent();
        }
        public AddTeacher(List<string> rewardname, List<string> rewardyear, List<BitmapImage> rewardimage) : this()
        {
            for (int i = 0; i < rewardname.Count; i++)
            {
                this.rewardname.Add(rewardname[i]);
                this.rewardyear.Add(rewardyear[i]);
                this.rewardimage.Add(rewardimage[i]);
            }
        }
        public void MainMenu(object sender, EventArgs e)
        {
            this.Hide();
            MainWindow ma = new MainWindow();
            ma.Show();
        }

        public void rewardlistClick(object sender, EventArgs e)
        {
            this.Hide();
            RewardsList fl = new RewardsList("teacher", rewardname, rewardyear,rewardimage);
            fl.Show();
        }

        public void schoollistClick(object sender, EventArgs e)
        {
            this.Hide();
            SchoolHistory fl = new SchoolHistory("teacher");
            fl.Show();
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
            MySqlCommand command = new MySqlCommand("INSERT INTO `workers` (`name`, `surname`, `fathername`, `category`, `iin`, `image`) VALUES (@uN, @uS, @uF, @uG, @uI, @uP)", db.getConnection());
            command.Parameters.Add("@uN", MySqlDbType.VarChar).Value = NameTextBox.Text;
            command.Parameters.Add("@uS", MySqlDbType.VarChar).Value = SurnameTextBox.Text;
            command.Parameters.Add("@uF", MySqlDbType.VarChar).Value = OtceTextBox.Text;
            command.Parameters.Add("@uG", MySqlDbType.VarChar).Value = CategoryTextBox.Text;
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
            for (int i = 0; i < rewardimage.Count; i++)
            {
                byte[] data;
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(rewardimage[i]));
                using (MemoryStream ms = new MemoryStream())
                {
                    encoder.Save(ms);
                    data = ms.ToArray();
                    MySqlCommand command1 = new MySqlCommand("INSERT INTO `rewards` (`name`, `year`, `iin`, `image`) VALUES (@uN, @uS, @uF, @uI)", db.getConnection());
                    command1.Parameters.Add("@uN", MySqlDbType.VarChar).Value = rewardname[i];
                    command1.Parameters.Add("@uS", MySqlDbType.VarChar).Value = rewardyear[i];
                    command1.Parameters.Add("@uF", MySqlDbType.VarChar).Value = IINTextBox.Text;
                    command1.Parameters.Add("@uI", MySqlDbType.Blob).Value = data;
                    if (command1.ExecuteNonQuery() == 1)
                    {

                    }



                }

            }
            db.closeConnection();
        }
    }
}
