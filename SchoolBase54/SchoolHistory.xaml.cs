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
    /// Логика взаимодействия для SchoolHistory.xaml
    /// </summary>
    public partial class SchoolHistory : Window
    {
        public SchoolHistory()
        {
            InitializeComponent();
        }
        string window;
        public SchoolHistory(string window):this()
        {
            this.window = window;
        }
        public void MainMenu(object sender, EventArgs e)
        {
            this.Hide();
            if (window=="schoolar")
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

        public void AddSchoolHistory(object sender, EventArgs e)
        {
            this.Hide();
            AddSchoolHistory a = new AddSchoolHistory(window);
            a.Show();
        }
    }
}
