using MinecraftAdvanced.Models;
using MinecraftAdvanced.ViewModels;
using MinecraftAdvanced.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MinecraftAdvanced.Views
{
    public partial class ItemsPage : ContentPage
    {
        public List<Item> Items { get; set; }

        public ItemsPage(string itemsName)
        {
            InitializeComponent();
            Items = App.DataStorage[itemsName];
            Title = "Items";
            BindingContext = this;

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}