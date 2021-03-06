
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Table;
using DAL.Interface;

namespace DAL.Repository
{
    public class TypeRepositorySQL : IRepository<Type>
    {
        private SEContext db;
        public TypeRepositorySQL(SEContext dbContext)
        {
            db = dbContext;
        }
        public void Create(Type item)
        {
            db.Type.Add(item);
        }

        public void Delete(int id)
        {
            Type type = db.Type.Find(id);
            if (type != null)
                db.Type.Remove(type);
        }

        public List<Type> GetAll()
        {
            return db.Type.ToList();
        }

        public Type GetItem(int id)
        {
            return db.Type.Find(id);
        }

        public void Update(Type item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
