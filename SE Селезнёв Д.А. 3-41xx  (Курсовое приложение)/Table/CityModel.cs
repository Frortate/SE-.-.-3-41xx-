using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Table;

namespace SE_Селезнёв_Д.А._3_41xx___Курсовое_приложение_.Table
{
    public class CityModel
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public CityModel()
        {
        }

        public CityModel(City c)
        {
            ID = c.Id;
            Name = c.Name;
        }
    }
}
