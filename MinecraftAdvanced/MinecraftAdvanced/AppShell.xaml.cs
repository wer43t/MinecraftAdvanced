﻿using MinecraftAdvanced.ViewModels;
using MinecraftAdvanced.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MinecraftAdvanced
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(FavouritesPage), typeof(FavouritesPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FavouritesPage());
        }
    }
}
