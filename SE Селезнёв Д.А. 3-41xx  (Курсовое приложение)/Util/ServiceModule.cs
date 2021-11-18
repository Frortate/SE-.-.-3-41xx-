using DAL.Interface;
using DAL.Repository;
using Ninject.Modules;

namespace SE_Селезнёв_Д.А._3_41xx___Курсовое_приложение_.Util
{
    public class ServiceModule : NinjectModule
    {
        public string connectionString;
        public ServiceModule(string connection)
        {
            connectionString = connection;
        }
        public override void Load()
        {
            Bind<IntDbRepository>().To<DbRepositorySQL>().InSingletonScope().WithConstructorArgument(connectionString);

        }
    }
}

