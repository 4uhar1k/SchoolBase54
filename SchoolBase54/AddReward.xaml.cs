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
        List<string> rewardname = new List<string>();
        List<string> rewardyear = new List<string>();
        List<BitmapImage> rewardimage = new List<BitmapImage>();
        public AddReward(string window, List<string> rewardname, List<string> rewardyear, List<BitmapImage> rewardimage) : this()
        {
            this.window = window;
            for (int i = 0; i < rewardname.Count; i++)
            {
                this.rewardname.Add(rewardname[i]);
                this.rewardyear.Add(rewardyear[i]);
            }
        }
        
        public void MainMenu(object sender, EventArgs e)
        {
            this.Hide();
            RewardsList ma = new RewardsList(window, rewardname, rewardyear, rewardimage);
            ma.Show();
        }

        public void readyclick(object sender, EventArgs e)
        {
            rewardname.Add(RewardNameTextBox.Text);
            rewardyear.Add(YearRewardTextBox.Text);
            rewardimage.Add(new BitmapImage(new Uri(imagepath.Content.ToString())));
            MessageBox.Show("Достижение добавлено успешно");
            
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
