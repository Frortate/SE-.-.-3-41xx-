using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Table
{
    public class Report
    {
        public int NumLikeEvents { get; set; }
        public string LikeUserCategory { get; set; }
        public string LikeUserType { get; set; }
        public List<Session> LikeUserEvents { get; set; }
    }
}
