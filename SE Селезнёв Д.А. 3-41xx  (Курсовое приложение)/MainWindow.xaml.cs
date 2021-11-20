
using Ninject;
using SE_Селезнёв_Д.А._3_41xx___Курсовое_приложение_.Table;
using SE_Селезнёв_Д.А._3_41xx___Курсовое_приложение_.View;
using System.Windows;
using System.Windows.Input;
using System.Configuration;
using SE_Селезнёв_Д.А._3_41xx___Курсовое_приложение_.Util;
using Microsoft.Toolkit.Uwp.Notifications;
using System;

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


            string connection = ConfigurationManager.ConnectionStrings["SEContext"].ConnectionString;
            var kernel = new StandardKernel(new ServiceModule(connection), new NinjectRegistrations());

            IDbCrud crud = kernel.Get<IDbCrud>();


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

        private void ButtLogout_Click(object sender, RoutedEventArgs e)
        {
            var notyfy = new ToastContentBuilder();
            notyfy.AddText("Жаль что вы ушли :( \nБудем ждать вас снова");
            notyfy.AddAppLogoOverride(new Uri
                (@"C:\Users\Frortate\Desktop\КУРСОВАЯ\Курсовая WPF SE\SE Селезнёв Д.А. 3-41xx  (Курсовое приложение)\SE Селезнёв Д.А. 3-41xx  (Курсовое приложение)\Image\notpage.png"));
            notyfy.Show();
        }
    }
}
