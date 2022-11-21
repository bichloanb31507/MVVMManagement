using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfShop.Data.Dao;

namespace WpfShop.ViewModels
{
    public class CreateUserViewModel : ViewModelBase
    {
        private String _firstName;
        private String _lastName;
        private String _sex;
        private String _address;
        private String _city;
        private String _email;
        private String _phone;
        private String _avatar;

        private ObservableCollection<String> _cities;
        private byte[] _image;

        public ICommand ChooseSexCommand { get; }
        public ICommand ChooseFileCommand { get; }
        public ICommand CreateUserCommand { get; }

        public CreateUserViewModel()
        {
            InitData();
            ChooseSexCommand = new ViewModelCommand(ExcuteChooseSexCommand);
            ChooseFileCommand = new ViewModelCommand(ExcuteChooseFileCommand);
            CreateUserCommand = new ViewModelCommand(ExecuteCreateUserCommand);
        }

        private void InitData()
        {
            CityDao cityDao = DataDao.Instance().GetCityDao();
            Cities = new ObservableCollection<String>(cityDao.findAll());
        }

        private void ExcuteChooseSexCommand(object obj)
        {
            if (obj != null)
            {
                Sex = (String)obj;
            }
        }

        private void ExcuteChooseFileCommand(object obj)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            
            if (dlg.ShowDialog() == true)
            {
                Avatar = dlg.FileName;
                FileStream fs = new FileStream(dlg.FileName, FileMode.Open,FileAccess.Read);
                Image = new byte[fs.Length];
                fs.Read(Image, 0, System.Convert.ToInt32(fs.Length));
                fs.Close();
            }
        }

        private void ExecuteCreateUserCommand(object obj)
        {
            user user = new user();

            user.first_name = FirstName;
            user.last_name = LastName;
            user.sex = Sex == "Male" ? false : true;
            user.address = Address;
            user.city = City;
            user.email = Email;
            user.phone = Phone;
            user.images = Image;
            user.path = Avatar;

            UserDao userDao = DataDao.Instance().GetUserDao();

            userDao.insert(user);
        }

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        public string Sex
        {
            get => _sex;
            set
            {
                _sex = value;
                OnPropertyChanged(nameof(Sex));
            }
        }

        public string Address
        {
            get => _address;
            set
            {
                _address = value;
                OnPropertyChanged(nameof(Address));
            }
        }

        public string City
        {
            get => _city;
            set
            {
                _city = value;
                OnPropertyChanged(nameof(City));
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public string Phone
        {
            get => _phone;
            set
            {
                _phone = value;
                OnPropertyChanged(nameof(Phone));
            }
        }

        public string Avatar
        {
            get => _avatar;
            set
            {
                _avatar = value;
                OnPropertyChanged(nameof(Avatar));
            }
        }

        public ObservableCollection<String> Cities
        {
            get { return _cities; }
            set { _cities = value; }
        }

        public byte[] Image
        {
            get { return _image; }
            set { _image = value; }
        }
    }
}
