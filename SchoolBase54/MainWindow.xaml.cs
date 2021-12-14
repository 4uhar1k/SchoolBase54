using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
        
        public void AddStudent(object sender, EventArgs e)
        {
            this.Hide();
            AddStudent st = new AddStudent();
            st.Show();
        }

        public void AddTeacher(object sender, EventArgs e)
        {
            this.Hide();
            AddTeacher st = new AddTeacher();
            st.Show();
        }

        public void bebra(object sender, EventArgs e)
        {
            DB db = new DB();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `schoolars` WHERE `iin` = 051012500555", db.getConnection());

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);


            DataTable table = new DataTable();

            adapter.Fill(table);
            db.openConnection();
            MySqlDataReader rdr1 = command.ExecuteReader();
            while (rdr1.Read())
            {
                byte[] data = (byte[])table.Rows[0][5]; // 0 is okay if you only selecting one column
                                                 //And use:
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream(data))
                {
                    var imageSource = new BitmapImage();
                    imageSource.BeginInit();
                    imageSource.StreamSource = ms;
                    imageSource.CacheOption = BitmapCacheOption.OnLoad;
                    imageSource.EndInit();

                    // Assign the Source property of your image
                    image1.Source = imageSource;
                }
            }
            db.closeConnection();
            /*string s = (string)table.Rows[0][3];
            byte[] img = System.Text.Encoding.ASCII.GetBytes(s);


            //MemoryStream ms = new MemoryStream(img);

            using (MemoryStream stream = new MemoryStream(img))
            {
                image1.Source = BitmapFrame.Create(stream,
                                                  BitmapCreateOptions.None,
                                                  BitmapCacheOption.OnLoad);
            }*/

            adapter.Dispose();
        }

    }
}
