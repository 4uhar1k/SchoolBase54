﻿using System;
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

        public void MainMenu(object sender, EventArgs e)
        {
            this.Hide();
            MainWindow ma = new MainWindow();
            ma.Show();
        }

        public void AddReward(object sender, EventArgs e)
        {
            this.Hide();
            AddReward a = new AddReward();
            a.Show();
        }
    }
}
