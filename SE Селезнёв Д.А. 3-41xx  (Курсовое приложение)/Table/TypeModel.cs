using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Table;

namespace SE_Селезнёв_Д.А._3_41xx___Курсовое_приложение_.Table
{
    public class TypeModel
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public TypeModel()
        {
        }
        public TypeModel(DAL.Table.Type t)
        {
            ID = t.ID;
            Name = t.Name;
        }
    }
}
