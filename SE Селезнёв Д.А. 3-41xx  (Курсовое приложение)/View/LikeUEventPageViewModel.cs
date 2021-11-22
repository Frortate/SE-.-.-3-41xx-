using SE_Селезнёв_Д.А._3_41xx___Курсовое_приложение_.Command;
using SE_Селезнёв_Д.А._3_41xx___Курсовое_приложение_.Interface;
using SE_Селезнёв_Д.А._3_41xx___Курсовое_приложение_.Table;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SE_Селезнёв_Д.А._3_41xx___Курсовое_приложение_
{
    class LikeUEventPageViewModel : INotifyPropertyChanged, IWindowPage
    {
        IDbCrud crud;
        IEvent iev;

        public LikeUEventPageViewModel(IDbCrud crud, IEvent iev, int userId)
        {
            this.crud = crud;
            this.iev = iev;
            Events = new ObservableCollection<EventModel>(crud.UserSessions(userId).Where(i => i.CurSession.IsDone == false).OrderBy(i => i.CurSession.Date).ToList());

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        TypeWindow IWindowPage.GetWindowType()
        {
            return TypeWindow.LikeEventsPage;
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

        private RelayCommand openEvent;
        public RelayCommand OpenEvent
        {
            get
            {
                return openEvent ??
                    (openEvent = new RelayCommand(obj =>
                    {
                        string title = obj.ToString();
                        EventModel em = Events.ToList().Find(e => e.Title == title);
                        if (em != null) iev.ClickEvent(em);
                    }
                ));
            }
        }
    }

}
