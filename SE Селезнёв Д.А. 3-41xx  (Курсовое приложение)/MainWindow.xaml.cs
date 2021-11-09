﻿using DAL.Repository;
using SE_Селезнёв_Д.А._3_41xx___Курсовое_приложение_.Table;
using SE_Селезнёв_Д.А._3_41xx___Курсовое_приложение_.View;
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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace SE_Селезнёв_Д.А._3_41xx___Курсовое_приложение_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DbRepositorySQL db = new DbRepositorySQL();
            CRUD crud = new CRUD(db);
            
            DataContext = new MainWindowViewModel(crud);
            
        }


        private void ButtMinWind_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void ButtCloseWind_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Header_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
