using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Table;
using DAL.Interface;

namespace DAL.Repository
{
    public class PlaceRepositorySQL : IRepository<Place>
    {
        private SEContext db;
        public PlaceRepositorySQL(SEContext dbContext)
        {
            db = dbContext;
        }
        public void Create(Place item)
        {
            db.Place.Add(item);
        }

        public void Delete(int id)
        {
            Place place = db.Place.Find(id);
            if (place != null)
                db.Place.Remove(place);
        }

        public List<Place> GetAll()
        {
            return db.Place.ToList();
        }

        public Place GetItem(int id)
        {
            return db.Place.Find(id);
        }

        public void Update(Place item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
