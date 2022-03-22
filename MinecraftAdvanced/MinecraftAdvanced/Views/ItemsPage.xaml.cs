using MinecraftAdvanced.Models;
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
            Title = itemsName;
            BindingContext = this;

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new SelectedItemPage(lvItems.SelectedItem as Item));
        }
    }
}