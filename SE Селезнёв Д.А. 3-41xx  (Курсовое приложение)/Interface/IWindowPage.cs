using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Селезнёв_Д.А._3_41xx___Курсовое_приложение_.Interface
{
    public enum TypeWindow { CatalogPage, EventPage, LikeEventsPage, ReportPage, LoginPage }
    public interface IWindowPage
    {
        TypeWindow GetWindowType();
    }


}
