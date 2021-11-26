using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface;
using DAL.Table;

namespace DAL.Repository
{
    public class ReportRepositorySQL : IntReportRepository
    {
        private SEContext dbcontext;
        public ReportRepositorySQL(SEContext rep)
        {
            dbcontext = rep;
        }
        public Report ReportUser(int userId, int month)
        {
            List<Session> sessions = dbcontext.User.Find(userId).Session.Where(i => i.Date < DateTime.Now && i.Date.Month == month).ToList();
            int count = sessions.Count;
            if (count == 0)
                return null;
            int categoryId = sessions
                .Select(i => i.EventsOrganizers.Event.Category)
                .GroupBy(i => i.ID)
                .OrderByDescending(i => i.Count())
                .First()
                .Key;
            string category = dbcontext.Category.Find(categoryId).Name;
            int typeId = sessions
                .Select(i => i.EventsOrganizers.Event.Type)
                .GroupBy(i => i.ID)
                .OrderByDescending(i => i.Count())
                .First()
                .Key;
            string type = dbcontext.Type.Find(typeId).Name;

            List<Session> events = dbcontext.User.Find(userId).Session
                .Where(i => i.Date < DateTime.Now && i.Date.Month == month)
                .ToList();

            Report result = new Report()
            {
                NumLikeEvents = count,
                LikeUserCategory = category,
                LikeUserType = type,
                LikeUserEvents = events
                
            };
            return result;
        }
    }
}
