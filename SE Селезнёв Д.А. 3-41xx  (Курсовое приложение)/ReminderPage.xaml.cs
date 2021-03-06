using SE_Селезнёв_Д.А._3_41xx___Курсовое_приложение_.Table;
using SE_Селезнёв_Д.А._3_41xx___Курсовое_приложение_.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для ReminderPage.xaml
    /// </summary>
    public partial class ReminderPage : Window
    {
        public ReminderPage(List<EventModel> notifyLikeEvents)
        {
            InitializeComponent();

            DataContext = new ReminderPageViewModel(notifyLikeEvents);
        }


        private void ButtCloseWind_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void HyperlinkToSite(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}
