using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface;
using DAL;
using DAL.Repository;
using DAL.Table;
using System.Windows;
using Microsoft.Toolkit.Uwp.Notifications;

namespace SE_Селезнёв_Д.А._3_41xx___Курсовое_приложение_.Table
{
    public class CRUD : IDbCrud
    {
        IntDbRepository db;
        IntReportRepository report;

        public CRUD(IntDbRepository repos, IntReportRepository report)
        {
            db = repos;
            this.report = report;
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
            var notyfy = new ToastContentBuilder();
            User u = db.Users.GetAll().Where(i => i.Login == user.Login).Where(i => i.Password == user.Password).FirstOrDefault();
            if(u == null)
            {
                {
                    notyfy.AddText("НЕУДАЧА! \nНе получилось войти в аккаунт \nНеверный логин или пароль");
                    notyfy.AddAppLogoOverride(new Uri
                        (@"C:\Users\Frortate\Desktop\КУРСОВАЯ\Курсовая WPF SE\SE Селезнёв Д.А. 3-41xx  (Курсовое приложение)\SE Селезнёв Д.А. 3-41xx  (Курсовое приложение)\Image\notpage.png"));
                    notyfy.Show();
                }
                return null;
            }
            return new UserModel(u);
        }

        public List<EventModel> UserSessions(int userId)
        {
            return db.Users.GetItem(userId).Session.Select(i => new EventModel(i.EventsOrganizers.Event, new SessionModel(i))).ToList();
        }

        public bool Like(int userId, int sessionId)
        {
            User user = db.Users.GetItem(userId);
            Session session = user.Session.FirstOrDefault(i => i.ID == sessionId);
            bool result;
            if (session != null)
            {
                user.Session.Remove(session);
                result = false;
            }
            else
            {
                user.Session.Add(db.Sessions.GetItem(sessionId));
                result = true;
            }

            Save();
            return result;
        }

        public List<EventModel> GetReminderLikeEventUser(int userId)
        {
            return db.Users.GetItem(userId).Session.Select(i => new EventModel(i.EventsOrganizers.Event, new SessionModel(i))).Where(i => i.CurSession.Date >= DateTime.Now && i.CurSession.Date < DateTime.Today.AddDays(8)).ToList();
        }

        public ReportModel ReportUser(int userId, int month)
        {
            var rept = report.ReportUser(userId, month);
            if (rept == null)
                return null;
            return new ReportModel()
            {
                NumLikeEvents = rept.NumLikeEvents,
                LikeUserCategory = rept.LikeUserCategory,
                LikeUserType = rept.LikeUserType,
                LikeUserEvents = rept.LikeUserEvents.Select(i => new EventModel(i.EventsOrganizers.Event, new SessionModel(i))).ToList()
            };
        }

        public bool RegTrue(UserModel user)
        {
            if (string.IsNullOrWhiteSpace(user.Login) || string.IsNullOrWhiteSpace(user.Password))
                return false;

            bool isExist;
            isExist = db.Users.GetAll()
                .Where(i => i.Login == user.Login)
                .Where(i => i.Password == user.Password)
                .FirstOrDefault() == null ? false : true;
            if (isExist)
                return false;

            db.Users.Create(new User { Login = user.Login, Password = user.Password });
            Save();
            return true;
        }

        public bool Save()
        {
            if (db.Save() > 0) return true;
            return false;                                                                             
        }


    }
}



        
    

