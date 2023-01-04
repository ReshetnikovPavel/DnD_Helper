using DndHelper.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DnD_Helper
{
    public partial class MenuPage : ContentPage
    {
        public MenuPage(MenuModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
