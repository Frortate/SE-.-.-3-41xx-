﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DAL.Table;

namespace SE_Селезнёв_Д.А._3_41xx___Курсовое_приложение_.Table
{
    public class UserModel
    {
        public int ID { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }
        public List<SessionModel> Sessions { get; set; }

        public UserModel()
        {

        }
        public UserModel(string login, string password)
        {
            Login = login;
            
            Password = password;
              
        }

        public UserModel(User u)
        {

            ID = u.ID;
            Login = u.Login;
            Password = u.Password;
            Sessions = u.Session.Select(i => new SessionModel(i)).ToList();
        }
    }
}
