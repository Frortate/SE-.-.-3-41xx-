using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SE_Селезнёв_Д.А._3_41xx___Курсовое_приложение_.Table;

namespace SE_Селезнёв_Д.А._3_41xx___Курсовое_приложение_.View
{
    class MainWindowViewModel
    {
        IDbCrud tm;

        public MainWindowViewModel(IDbCrud tm)
        {
            this.tm = tm;
            GetAllEvents();

        }

        private ObservableCollection<EventModel> events;
        public ObservableCollection<EventModel> Events
        {
            get { return events; }
            set
            {
                events = value;
                OnPropertyChanged("Events");
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public void GetAllEvents()
        {
            Events = new ObservableCollection<EventModel>(tm.GetEvents());

        }

    }


}
