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
    class ReportLikeEventPageViewModel : INotifyPropertyChanged, IWindowPage
    {

        IDbCrud crud;


        public ReportLikeEventPageViewModel(IDbCrud crud, int logUser)
        {
            this.crud = crud;
            LogUser = logUser;

            SelectDate = 0;
        }

        public int LogUser { get; set; }

        TypeWindow IWindowPage.GetWindowType()
        {
            return TypeWindow.ReportPage;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private ReportModel reports;
        public ReportModel Reports
        {
            get { return reports; }
            set 
            { 
                reports = value;
                OnPropertyChanged("Reports"); 
                IsOk = reports != null; 
            }
        }
        private bool isOk;
        public bool IsOk
        {
            get { return isOk; }
            set 
            { 
                isOk = value; 
                OnPropertyChanged("IsOk"); 
            }
        }

        private int selectDate;
        public int SelectDate
        {
            get { return selectDate; }
            set 
            { 
                selectDate = value; 
                Reports = crud.ReportUser(LogUser, SelectDate + 1); 
            }
        }

        private RelayCommand pdfReport;
        public RelayCommand PdfReport
        {
            get
            {
                return pdfReport ??
                    (pdfReport = new RelayCommand(obj =>
                    {
                        Microsoft.Win32.SaveFileDialog s = new Microsoft.Win32.SaveFileDialog();
                        string month = new DateTime(2021, selectDate + 1, 1).ToString("MMMM");
                        s.FileName = "Отчёт для пользователя - " + crud.User(LogUser).Login;
                        s.DefaultExt = ".pdf";
                        if (s.ShowDialog() == true)
                            ConvertToPDF.ConcertInfoPDF(s.FileName, Reports, month);

                    }
                ));
            }
        }
    }
}
