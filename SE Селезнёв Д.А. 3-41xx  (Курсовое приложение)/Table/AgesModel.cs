using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Table;

namespace SE_Селезнёв_Д.А._3_41xx___Курсовое_приложение_.Table
{
    public class AgesModel
    {
        public int ID { get; set; }

        public int Age { get; set; }

        public AgesModel()
        {
        }
        public AgesModel(Ages r)
        {
            ID = r.ID;
            Age = r.Age;
        }
    }
}
