﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SE_Селезнёв_Д.А._3_41xx___Курсовое_приложение_.Command;
using SE_Селезнёв_Д.А._3_41xx___Курсовое_приложение_.Interface;
using SE_Селезнёв_Д.А._3_41xx___Курсовое_приложение_.Table;

namespace SE_Селезнёв_Д.А._3_41xx___Курсовое_приложение_.View
{
    class MainWindowViewModel : INotifyPropertyChanged, IEvent
    {
        IDbCrud crud;

        public MainWindowViewModel(IDbCrud crud)
        {
            this.crud = crud;
            
            TypePage = new CatalogPageViewModel(crud, this);
            

        }

        public void ClickEvent(EventModel em)
        {

            TypePage = new OpenButEventViewModel(crud, this, em);

        }

        private IWindowPage typePage;
        public IWindowPage TypePage
        {
            get
            {
                return typePage;
            }
            set
            {
                if (typePage != value)
                {
                    typePage = value;
                    OnPropertyChanged("TypePage");
                }
            }
        }

        
        private RelayCommand openCatalog;
        public RelayCommand OpenCatalog
        {
            get
            {
                return openCatalog ??
                    (openCatalog = new RelayCommand(obj =>
                    {
                        TypePage = new CatalogPageViewModel(crud, this);
                    }
                ));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }


        private bool wentIn;
        public bool WentIn
        {
            get { return wentIn; }
            set { wentIn = value; ; OnPropertyChanged("WentIn"); }
        }

        private RelayCommand logIn;
        public RelayCommand LogIn
        {
            get
            {
                return logIn ??
                    (logIn = new RelayCommand(obj =>
                    {
                        PageLogin login = new PageLogin(crud);
                        bool? result = login.ShowDialog();
                        if (result == true)
                        {
                            WentIn = true;
                        }
                    }
                ));
            }
        }

        private RelayCommand loginOut;
        public RelayCommand LoginOut
        {
            get
            {
                return loginOut ??
                    (loginOut = new RelayCommand(obj =>
                    {
                        WentIn = false;
                        
                        if (TypePage.GetWindowType() != TypeWindow.CatalogPage)
                            TypePage = new CatalogPageViewModel(crud, this);
                    }
                ));
            }
        }

        
    }


}



