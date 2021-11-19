
using Ninject;
using SE_Селезнёв_Д.А._3_41xx___Курсовое_приложение_.Table;
using SE_Селезнёв_Д.А._3_41xx___Курсовое_приложение_.View;
using System.Windows;
using System.Windows.Input;
using System.Configuration;
using SE_Селезнёв_Д.А._3_41xx___Курсовое_приложение_.Util;


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
            //DbRepositorySQL db = new DbRepositorySQL();
            //CRUD crud = new CRUD(db);


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

       
    }
}
