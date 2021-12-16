using DAL.Table;
using DAL.Interface;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class CityRepositorySQL : IRepository<City>
    {
        private SEContext db;
        public CityRepositorySQL(SEContext dbContext)
        {
            db = dbContext;
        }
        public void Create(City item)
        {
            db.City.Add(item);
        }

        public void Delete(int id)
        {
            City city = db.City.Find(id);
            if (city != null)
                db.City.Remove(city);
        }

        public List<City> GetAll()
        {
            return db.City.ToList();
        }

        public City GetItem(int id)
        {
            return db.City.Find(id);
        }

        public void Update(City item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
