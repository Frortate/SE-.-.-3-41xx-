using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface;
using DAL;
using DAL.Repository;

namespace SE_Селезнёв_Д.А._3_41xx___Курсовое_приложение_.Table
{
    public class CRUD : IDbCrud
    {
        IntDbRepository db;
        

        public CRUD(IntDbRepository repos)
        {
            db = repos;
            
        }

        public List<EventModel> GetEvents()
        {
            return db.Events.GetAll().Select(i => new EventModel(i))
                .Where(i => i.Sessions.Where(s => s.IsDone == false).Count() > 0).ToList();
        }

        
    }
}
