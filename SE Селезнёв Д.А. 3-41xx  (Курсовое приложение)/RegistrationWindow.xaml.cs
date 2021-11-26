using Microsoft.Toolkit.Uwp.Notifications;
using SE_Селезнёв_Д.А._3_41xx___Курсовое_приложение_.Interface;
using SE_Селезнёв_Д.А._3_41xx___Курсовое_приложение_.Table;
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

namespace SE_Селезнёв_Д.А._3_41xx___Курсовое_приложение_
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window, ILogin
    {
       
        public RegistrationWindow(IDbCrud db)
        {
            InitializeComponent();

            DataContext = new RegistrationWindowViewModel(db, this);
        }

        private void ButtCloseWind_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public string GetPassword()
        {

            return Password.Password;
        }
        public void CloseLogin(bool? resultLog, UserModel user)
        {
            var notyfy = new ToastContentBuilder();
            notyfy.AddText("ПОЗДРАВЛЯЕМ! \nРегистрация прошла успешно.");
            notyfy.AddAppLogoOverride(new Uri
                (@"C:\Users\Frortate\Desktop\КУРСОВАЯ\Курсовая WPF SE\SE Селезнёв Д.А. 3-41xx  (Курсовое приложение)\SE Селезнёв Д.А. 3-41xx  (Курсовое приложение)\Image\notpage.png"));
            notyfy.Show();
            this.Close();

        }

    }
}
