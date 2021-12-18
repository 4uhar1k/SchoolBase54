using Microsoft.Win32;
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
    /// Логика взаимодействия для AddReward.xaml
    /// </summary>
    public partial class AddReward : Window
    {
        public AddReward()
        {
            InitializeComponent();
        }
        string window;
        public AddReward(string window) : this()
        {
            this.window = window;
        }
        
        public void MainMenu(object sender, EventArgs e)
        {
            this.Hide();
            RewardsList ma = new RewardsList(window);
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
    }
}
