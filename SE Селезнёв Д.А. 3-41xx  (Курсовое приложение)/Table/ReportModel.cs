using DAL.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Селезнёв_Д.А._3_41xx___Курсовое_приложение_.Table
{
    public class ReportModel
    {
        public int NumLikeEvents { get; set; }
        public string LikeUserCategory { get; set; }
        public string LikeUserType { get; set; }
        public List<EventModel> LikeUserEvents { get; set; }
    }
}
