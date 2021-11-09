using DAL.Table;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IntDbRepository
    {
        IntRepository<User> Users { get; }
        IntRepository<Session> Sessions { get; }
        IntRepository<Event> Events { get; }
        IntRepository<Place> Places { get; }
        IntRepository<City> Cities { get; }
        IntRepository<EventsOrganizers> EventsOrganizers { get; }
        IntRepository<Category> Categories { get; }
        IntRepository<Type> Types { get; }
        int Save();
    }
}
