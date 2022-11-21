using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfShop.Data.Dao
{
    public interface CityDao
    {
        void insert(city city);
        void update(city city);
        List<String> findAll();
        int count();
        city findById(int id);
        void deleteById(int id);
    }
}
