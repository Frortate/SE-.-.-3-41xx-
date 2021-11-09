using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Table;

namespace SE_Селезнёв_Д.А._3_41xx___Курсовое_приложение_.Table
{
    public class CategoryModel
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public CategoryModel()
        {
        }

        public CategoryModel(Category c)
        {
            ID = c.ID;
            Name = c.Name;
        }
    }
}
