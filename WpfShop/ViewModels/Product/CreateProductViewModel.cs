using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace WpfShop.ViewModels
{
    public class CreateProductViewModel : ViewModelBase
    {
        public ICommand CreateProductCommand { get; }

        public CreateProductViewModel()
        {
            CreateProductCommand = new ViewModelCommand(ExecuteCreateProductCommand);
        }
        private void ExecuteCreateProductCommand(object obj)
        {
            
        }

    }
}
