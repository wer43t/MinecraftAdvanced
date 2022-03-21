using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MinecraftAdvanced.Models;

namespace MinecraftAdvanced.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectedItemPage : ContentPage
    {
        public SelectedItemPage(Item selectedItem)
        {
            InitializeComponent();
            BindingContext = selectedItem;
        }
    }
}