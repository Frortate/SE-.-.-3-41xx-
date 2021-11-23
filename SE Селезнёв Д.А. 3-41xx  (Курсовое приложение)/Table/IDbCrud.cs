using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Table;

namespace SE_Селезнёв_Д.А._3_41xx___Курсовое_приложение_.Table
{
    public interface IDbCrud
    {
        List<EventModel> GetEvents();
        List<EventModel> GetEventsCity(int city);
        List<CategoryModel> GetCategories();
        List<TypeModel> GetTypes();
        List<CityModel> GetCities();

        UserModel User(int id);
        UserModel LoginTrue(UserModel user);

        List<EventModel> UserSessions(int userId);

        bool Like(int userId, int sessionId);

        List<EventModel> GetReminderLikeEventUser(int userId);
    }
}
