﻿using SE_Селезнёв_Д.А._3_41xx___Курсовое_приложение_.Table;


namespace SE_Селезнёв_Д.А._3_41xx___Курсовое_приложение_.Interface
{
    public interface ILogin
    {
        string GetPassword();
        void CloseLogin(bool? resultLog = false, UserModel user = null);
    }
}
