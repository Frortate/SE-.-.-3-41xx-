using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Селезнёв_Д.А._3_41xx___Курсовое_приложение_.Interface
{
    public enum TypeWindow { MainWindow, EventWindow, FavouriteWindow, ReportWindow }
    public interface IWindowPage
    {
        TypeWindow GetWindowType();
    }


}
