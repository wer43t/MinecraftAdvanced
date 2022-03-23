﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinecraftAdvanced.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MinecraftAdvanced.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FavouritesPage : ContentPage
    {
        public List<FavouriteItem> Favourites { get; set; }
        public GoogleHelper helper;
        public FavouritesPage ()
        {
            helper = new GoogleHelper();
            Favourites = helper.GetFavourites();
            InitializeComponent();
            BindingContext = this;
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (sender as ListView).SelectedItem as FavouriteItem;

            await Navigation.PushAsync(new SelectedItemPage(item));
        }
    }
}