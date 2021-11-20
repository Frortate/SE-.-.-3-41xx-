using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface;
using DAL;
using DAL.Repository;
using DAL.Table;

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

        public List<EventModel> GetEventsCity(int city)
        {
            return db.Events.GetAll().Select(i => new EventModel(i)).Where(i => i.Sessions.Where(s => s.Organizer.Place.CityId == city).Count() > 0)
                .Where(i => i.Sessions.Where(s => s.IsDone == false).Count() > 0).ToList();
        }

        public List<CityModel> GetCities()
        {
            return db.Cities.GetAll().Select(i => new CityModel(i)).ToList();
        }

        public List<CategoryModel> GetCategories()
        {
            return db.Categories.GetAll().Select(i => new CategoryModel(i)).ToList();
        }
        public List<TypeModel> GetTypes()
        {
            return db.Types.GetAll().Select(i => new TypeModel(i)).ToList();
        }

        public UserModel User(int id)
        {
            return new UserModel(db.Users.GetItem(id));
        }

        public UserModel LoginTrue(UserModel user)
        {
            User u = db.Users.GetAll().Where(i => i.Login == user.Login).Where(i => i.Password == user.Password).FirstOrDefault();
            return new UserModel(u);
        }
    }
}
