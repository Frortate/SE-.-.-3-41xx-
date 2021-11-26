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
using System.Windows;

namespace SE_Селезнёв_Д.А._3_41xx___Курсовое_приложение_
{
    class RegistrationWindowViewModel : INotifyPropertyChanged
    {
        IDbCrud crud;
        ILogin login;


        public RegistrationWindowViewModel(IDbCrud crud, ILogin login)
        {
            this.crud = crud;
            this.login = login;

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public string Logined { get; set; }

        public string PasswordCont { get { return login.GetPassword(); } }

        private RelayCommand registrationWindow;
        public RelayCommand RegistrationWindow
        {
            get
            {
                return registrationWindow ??
                    (registrationWindow = new RelayCommand(obj =>
                    {
                        bool result = crud.RegTrue(new UserModel(Logined, PasswordCont));

                        if (result)
                            login.CloseLogin();

                    }
                ));
            }
        }

    }
}
