using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Table;


namespace SE_Селезнёв_Д.А._3_41xx___Курсовое_приложение_.Table
{
    public class EventModel 
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Site { get; set; }

        public byte[] Poster { get; set; }
        public bool IsNew { get; set; }
        public int TypeId { get; set; }

        public int CategoryId { get; set; }

        public int AgeId { get; set; }
        public AgesModel Ages { get; set; }
        public SessionModel CurSession { get; set; }
        public List<SessionModel> Sessions { get; set; }

        public EventModel() { }
        public EventModel(Event e)
        {
            ID = e.ID;
            Title = e.Title;
            Description = e.Description;
            Site = e.Site;
            Poster = e.Poster;
            IsNew = e.IsNew;
            TypeId = e.TypeId;
            CategoryId = e.CategoryId;
            AgeId = e.AgeId;
            Ages = new AgesModel(e.Ages);
            Sessions = e.EventsOrganizers.Select(i => i.Session).FirstOrDefault().Select(i => new SessionModel(i)).ToList();
        }

        public EventModel(Event e, SessionModel s)
        {
            ID = e.ID;
            Title = e.Title;
            Description = e.Description;
            Site = e.Site;
            Poster = e.Poster;
            IsNew = e.IsNew;
            TypeId = e.TypeId;
            CategoryId = e.CategoryId;
            AgeId = e.AgeId;
            Ages = new AgesModel(e.Ages);
            Sessions = e.EventsOrganizers.Select(i => i.Session).FirstOrDefault().Select(i => new SessionModel(i)).ToList();
            CurSession = s;
        }

    }
}
