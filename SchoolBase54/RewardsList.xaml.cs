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
    /// Логика взаимодействия для RewardsList.xaml
    /// </summary>
    public partial class RewardsList : Window
    {
        public RewardsList()
        {
            InitializeComponent();
        }


        string window;
        Label[] names, years;
        StackPanel[] rewards;
        List<string> rewardname = new List<string>();
        List<string> rewardyear = new List<string>();
        List<BitmapImage> rewardimage = new List<BitmapImage>();
        public RewardsList(string window, List<string> rewardname, List<string> rewardyear, List<BitmapImage> rewardimage) : this()
        {
            
            this.window = window;

                
                
            rewards = new StackPanel[10] { reward1, reward2, reward3, reward4, reward5, reward6, reward7, reward8, reward9, reward10 };
            names = new Label[10] {name1,name2,name3,name4,name5,name6,name7,name8,name9,name10};
            years = new Label[10] { year1, year2, year3, year4, year5, year6, year7, year8, year9, year10 };
            for (int i = 0; i < 10; i++)
            {
                rewards[i].Visibility = Visibility.Hidden;

            }
            for (int i = 0; i < rewardname.Count; i++)
            {
                
                this.rewardname.Add(rewardname[i]);
                this.rewardyear.Add(rewardyear[i]);
                this.rewardimage.Add(rewardimage[i]);
                rewards[i].Visibility = Visibility.Visible;
                names[i].Content = rewardname[i];
                years[i].Content = rewardyear[i];
                
                
            }
        }
        public void MainMenu(object sender, EventArgs e)
        {
            this.Hide();
            if (window == "schoolar")
            {
                AddStudent ma = new AddStudent(rewardname, rewardyear, rewardimage);
                ma.Show();
            }

            else
            {
                AddTeacher ma = new AddTeacher(rewardname, rewardyear, rewardimage);
                ma.Show();
            }


        }

        public void AddReward(object sender, EventArgs e)
        {
            this.Hide();
            AddReward a = new AddReward(window, rewardname, rewardyear, rewardimage);
            a.Show();
        }

        public void isSelected(object sender, EventArgs e)
        {
            searchbar.Text = "";
            searchbar.Foreground = Brushes.Black;
        }
    }
}
