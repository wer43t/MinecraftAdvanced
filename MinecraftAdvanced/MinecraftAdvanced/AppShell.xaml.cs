using MinecraftAdvanced.ViewModels;
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
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SelectTypePage((sender as MenuItem).Text.ToLower()));
        }
    }
}
