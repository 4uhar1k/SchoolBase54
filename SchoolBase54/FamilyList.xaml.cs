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
    /// Логика взаимодействия для FamilyList.xaml
    /// </summary>
    public partial class FamilyList : Window
    {
        public FamilyList()
        {
            InitializeComponent();
        }

        public void MainMenu (object sender, EventArgs e)
        {
            this.Hide();
            AddStudent ma = new AddStudent();
            ma.Show();
        }

        public void AddFamilyMember(object sender, EventArgs e)
        {
            this.Hide();
            AddFamilyMember a = new AddFamilyMember();
            a.Show();
        }
    }
}
