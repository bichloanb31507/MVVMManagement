using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using WpfShop.Data.Dao;

namespace WpfShop.ViewModels
{
    public class UserViewModel : ViewModelBase
    {
        private MainViewModel _mainViewModel;

        private ObservableCollection<user> _users;

        private string _size;

        public ICommand ShowCreateUserViewCommand { get; }
        public ICommand ShowEditUserViewCommand { get; }
        public ObservableCollection<user> Users
        {
            get { return _users; }
            set 
            { 
                _users = value;
                OnPropertyChanged(nameof(Users));
            }
        }

        public String Size 
        {
            get { return _size; }
            set { _size = value; } 
        }

        private void InitData()
        {
            UserDao userDao = DataDao.Instance().GetUserDao();
            _users = new ObservableCollection<user>(userDao.findAll());
            Size = userDao.count() + " User";
        }

        public UserViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            ShowCreateUserViewCommand = new ViewModelCommand(ExecuteShowCreateUserViewCommand);
            ShowEditUserViewCommand = new ViewModelCommand(ExecuteShowEditUserViewCommand);
            InitData();
        }
        private void ExecuteShowCreateUserViewCommand(object obj)
        {
            _mainViewModel.CurrentChildView = new CreateUserViewModel();
            _mainViewModel.Caption = "Create Users";
            _mainViewModel.Icon = IconChar.User;
        }

        private void ExecuteShowEditUserViewCommand(object obj)
        {
            int id = 2;
            _mainViewModel.CurrentChildView = new EditUserViewModel(id);
            _mainViewModel.Caption = "Edit Users";
            _mainViewModel.Icon = IconChar.User;
        }
    }
}