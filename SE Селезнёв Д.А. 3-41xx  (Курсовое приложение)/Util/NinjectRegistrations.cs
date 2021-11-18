using SE_Селезнёв_Д.А._3_41xx___Курсовое_приложение_.Table;
using Ninject.Modules;

namespace SE_Селезнёв_Д.А._3_41xx___Курсовое_приложение_.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IDbCrud>().To<CRUD>();
        }
    }
}
