using SE_Селезнёв_Д.А._3_41xx___Курсовое_приложение_.Table;
using Ninject.Modules;
using SE_Селезнёв_Д.А._3_41xx___Курсовое_приложение_.Interface;
using DAL.Interface;
using DAL.Repository;

namespace SE_Селезнёв_Д.А._3_41xx___Курсовое_приложение_.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IDbCrud>().To<CRUD>();
            Bind<ILogin>().To<PageLogin>().InSingletonScope();
            Bind<IReportRepository>().To<ReportRepositorySQL>();
        }
    }
}
