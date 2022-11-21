using WpfShop.Data.Dao;
using WpfShop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfShop.Data.Impl
{
    public class UserDaoImpl : UserDao
    {
        private ShopDataContext db;
        public UserDaoImpl()
        {
            db = new ShopDataContext(Constants.DB_CONNECT_STRING);
        }
        public int count()
        {
            var query = from user in db.GetTable<user>() select user;
            List<user> userList = query.ToList<user>();
            return userList.Count();
        }
        public void deleteById(int id)
        {
            user find = db.users.Single(us => us.id == id);
            db.users.DeleteOnSubmit(find);
            db.SubmitChanges();
        }
        public user checkLogin(string email, string password)
        {
            user user = null;
            try
            {
               user = db.users.Single(us => us.email == email && us.password == password);
            }
            catch (Exception ex) 
            {
                ex.ToString();
            }
            return user;
        }
        public List<user> findAll()
        {
            var all = from user in db.GetTable<user>() select user;
            var userList = all.ToList();
            return userList;
        }
        public user findById(int id)
        {
            return db.users.Single(us => us.id == id);
        }
        public void insert(user user)
        {
            db.users.InsertOnSubmit(user);
            db.SubmitChanges();
        }
        public void update(user user)
        {
            user find = db.users.Single(us => us.id == user.id);
            find.first_name = user.first_name;
            find.last_name = user.last_name;
            find.sex = user.sex;
            find.city = user.city;
            find.address = user.address;
            find.email = user.email;
            find.phone = user.phone;
            find.images = user.images;
            find.path = user.path;
            db.SubmitChanges();
        }
    }
}
