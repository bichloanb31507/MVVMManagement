using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfShop.Data.Dao
{
    public interface UserDao
    {
        void insert(user user);
        void update(user user);
        List<user> findAll();
        int count();
        user findById(int id);
        void deleteById(int id);
        user checkLogin(string phone, string password);
    }
}
