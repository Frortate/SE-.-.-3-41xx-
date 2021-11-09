using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Table;

namespace SE_Селезнёв_Д.А._3_41xx___Курсовое_приложение_.Table
{
    public class PlaceModel
    {
        public int ID { get; set; }

        public string Address { get; set; }


        public int CityId { get; set; }

        public City City { get; set; }


        public PlaceModel() { }
        public PlaceModel(Place p)
        {
            ID = p.ID;
            Address = p.Address;
            CityId = p.CityId;
            City = p.City;
        }
    }
}
