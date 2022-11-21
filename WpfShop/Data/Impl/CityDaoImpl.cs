using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfShop.Data.Dao;
using WpfShop.Utils;

namespace WpfShop.Data.Impl
{
    public class CityDaoImpl : CityDao
    {
        private ShopDataContext db;
        public CityDaoImpl()
        {
            db = new ShopDataContext(Constants.DB_CONNECT_STRING);
        }
        public int count()
        {
            throw new NotImplementedException();
        }

        public void deleteById(int id)
        {
            throw new NotImplementedException();
        }

        public List<String> findAll()
        {
            var all = from city in db.GetTable<city>() select city.name;
            var cityList = all.ToList();
            return cityList;
        }

        public city findById(int id)
        {
            throw new NotImplementedException();
        }

        public void insert(city city)
        {
            throw new NotImplementedException();
        }

        public void update(city city)
        {
            throw new NotImplementedException();
        }
    }
}
