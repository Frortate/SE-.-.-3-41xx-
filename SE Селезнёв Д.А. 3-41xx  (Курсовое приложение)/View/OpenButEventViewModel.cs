using SE_Селезнёв_Д.А._3_41xx___Курсовое_приложение_.Command;
using SE_Селезнёв_Д.А._3_41xx___Курсовое_приложение_.Interface;
using SE_Селезнёв_Д.А._3_41xx___Курсовое_приложение_.Table;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SE_Селезнёв_Д.А._3_41xx___Курсовое_приложение_
{
    class OpenButEventViewModel : INotifyPropertyChanged, IWindowPage
    {
        IDbCrud crud;
        IEvent iev;

        private EventModel openEvent;

        public EventModel OpenEvent
        {
            get { return openEvent; }
            set
            {
                openEvent = value;
                OnPropertyChanged("OpenEvent");
            }
        }



        public OpenButEventViewModel(IDbCrud crud, IEvent iev, EventModel em)
        {
            OpenEvent = em;

            OpenEvent.Sessions = OpenEvent.Sessions.Where(i => i.IsDone == false).OrderBy(i => i.Date).ToList();

            this.crud = crud;
            this.iev = iev;

            logUser = iev.GetUser();
            WentIn = logUser == -1 ? false : true;
            if (WentIn)
                CheckedForLike();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        TypeWindow IWindowPage.GetWindowType()
        {
            return TypeWindow.EventPage;
        }

        private int logUser;
        public bool WentIn { get; set; }


        private RelayCommand clickLike;
        public RelayCommand ClickLike
        {
            get
            {
                return clickLike ??
                    (clickLike = new RelayCommand(obj =>
                    {

                        int sessionId = (int)obj;
                        if (WentIn == false)
                            return;

                        bool result = crud.Like(logUser, sessionId);
                        CheckedForLike();
                    }
                ));
            }
        }

        private void CheckedForLike()
        {
            EventModel ev = OpenEvent;
            foreach (SessionModel s in ev.Sessions)
            {
                if (crud.User(logUser).Sessions.Where(i => i.ID == s.ID).FirstOrDefault() != null)
                    s.IsFavourite = true;
                else
                    s.IsFavourite = false;
            }
            OpenEvent = ev;
            OnPropertyChanged("CurrentEvent");
        }
    }
}
