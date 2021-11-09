using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Table
{
    public class Report
    {
        public int CountFavouriteEvents { get; set; }
        public string FavouriteCategory { get; set; }
        public string FavouriteType { get; set; }
        public List<Session> FavouriteEvents { get; set; }
    }
}
