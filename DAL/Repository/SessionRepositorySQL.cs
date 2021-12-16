using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Table;
using DAL.Interface;

namespace DAL.Repository
{
    public class SessionRepositorySQL : IRepository<Session>
    {
        private SEContext db;
        public SessionRepositorySQL(SEContext dbContext)
        {
            db = dbContext;
        }
        public void Create(Session item)
        {
            db.Session.Add(item);
        }

        public void Delete(int id)
        {
            Session session = db.Session.Find(id);
            if (session != null)
                db.Session.Remove(session);
        }

        public List<Session> GetAll()
        {
            return db.Session.ToList();
        }

        public Session GetItem(int id)
        {
            return db.Session.Find(id);
        }

        public void Update(Session item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
