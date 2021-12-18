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
        public RewardsList(string window) : this()
        {
            this.window = window;
        }
        public void MainMenu(object sender, EventArgs e)
        {
            this.Hide();
            if (window == "schoolar")
            {
                AddStudent ma = new AddStudent();
                ma.Show();
            }

            else
            {
                AddTeacher ma = new AddTeacher();
                ma.Show();
            }


        }

        public void AddReward(object sender, EventArgs e)
        {
            this.Hide();
            AddReward a = new AddReward(window);
            a.Show();
        }
    }
}
