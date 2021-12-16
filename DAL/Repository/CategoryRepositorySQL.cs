using DAL.Table;
using DAL.Interface;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class CategoryRepositorySQL : IRepository<Category>
    {
        private SEContext db;
        public CategoryRepositorySQL(SEContext dbContext)
        {
            db = dbContext;
        }
        public void Create(Category item)
        {
            db.Category.Add(item);
        }

        public void Delete(int id)
        {
            Category category = db.Category.Find(id);
            if (category != null)
                db.Category.Remove(category);
        }

        public List<Category> GetAll()
        {
            return db.Category.ToList();
        }

        public Category GetItem(int id)
        {
            return db.Category.Find(id);
        }

        public void Update(Category item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
