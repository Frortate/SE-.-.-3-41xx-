
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Table;
using DAL.Interface;

namespace DAL.Repository
{
    public class DbRepositorySQL : IntDbRepository
    {
        private SEContext db;

        private UserRepositorySQL userRepository;
        private SessionRepositorySQL sessionRepository;
        private EventRepositorySQL eventRepository;
        private PlaceRepositorySQL placeRepository;
        private CityRepositorySQL cityRepository;
        private EventsOrganizersRepositorySQL eventsOrganizersRepository;
        private CategoryRepositorySQL categoryRepository;
        private TypeRepositorySQL typeRepository;
        public DbRepositorySQL()
        {
            db = new SEContext();
        }

        public IntRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepositorySQL(db);
                return userRepository;
            }
        }

        public IntRepository<Session> Sessions
        {
            get
            {
                if (sessionRepository == null)
                    sessionRepository = new SessionRepositorySQL(db);
                return sessionRepository;
            }
        }

        public IntRepository<Event> Events
        {
            get
            {
                if (eventRepository == null)
                    eventRepository = new EventRepositorySQL(db);
                return eventRepository;
            }
        }

        public IntRepository<Place> Places
        {
            get
            {
                if (placeRepository == null)
                    placeRepository = new PlaceRepositorySQL(db);
                return placeRepository;
            }
        }
        public IntRepository<City> Cities
        {
            get
            {
                if (cityRepository == null)
                    cityRepository = new CityRepositorySQL(db);
                return cityRepository;
            }
        }

        public IntRepository<EventsOrganizers> EventsOrganizers
        {
            get
            {
                if (eventsOrganizersRepository == null)
                    eventsOrganizersRepository = new EventsOrganizersRepositorySQL(db);
                return eventsOrganizersRepository;
            }
        }

        public IntRepository<Category> Categories
        {
            get
            {
                if (categoryRepository == null)
                    categoryRepository = new CategoryRepositorySQL(db);
                return categoryRepository;
            }
        }

        public IntRepository<Type> Types
        {
            get
            {
                if (typeRepository == null)
                    typeRepository = new TypeRepositorySQL(db);
                return typeRepository;
            }
        }

        

        public int Save()
        {
            return db.SaveChanges();
        }
    }
}
