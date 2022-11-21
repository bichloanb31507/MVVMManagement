using WpfShop.Data.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfShop.Data.Dao
{
    public class SqlServerDataDao : DataDao
    {
        public override CityDao GetCityDao()
        {
            return new CityDaoImpl();
        }

        public override UserDao GetUserDao()
        {
            return new UserDaoImpl();
        }
    }
}
