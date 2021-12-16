using SE_Селезнёв_Д.А._3_41xx___Курсовое_приложение_.Table;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SE_Селезнёв_Д.А._3_41xx___Курсовое_приложение_.View
{
    class ReminderPageViewModel 
    {
        public ReminderPageViewModel(List<EventModel> em)
        {
            NotifyLikeEvents = em;
        }

        public List<EventModel> NotifyLikeEvents { get; set; }

        
        
    }
}
