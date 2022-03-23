using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;
using MinecraftAdvanced.Models;
using System.Linq;

namespace MinecraftAdvanced.Views
{
    public partial class MainPage : ContentPage
    {
        public List<Item> Buildings { get; set; }
        public List<string> Names { get; set; }
        public GoogleHelper helper = new GoogleHelper();
        public List<Button> Buttons { get; set; }

        public MainPage()
        {
            InitializeComponent();
            Buildings = new List<Item>();
            FillTops();

            this.BindingContext = this;
        }
        public void FillTops()
        {
            var maps = App.DataStorage["карты"];
            var buildings = App.DataStorage["постройки"];
            var addons = App.DataStorage["аддоны"];
            var textures = App.DataStorage["текстуры"];
            var seeds = App.DataStorage["сиды"];

            Buildings.Add(maps[5]);
            Buildings.Add(buildings[5]);
            Buildings.Add(addons[5]);
            Buildings.Add(textures[5]);
            Buildings.Add(seeds[5]);

            for (int i = 0; i < 5; i++)
            { 
                MapsLayout.Children.Add(new Image() { Source = maps[i].Image });
                BuildingsLayout.Children.Add(new Image() { Source = buildings[i].Image });
                AddonsLayout.Children.Add(new Image() { Source = addons[i].Image });
                TexturesLayout.Children.Add(new Image() { Source = textures[i].Image });
                SeedsLayout.Children.Add(new Image() { Source = seeds[i].Image });
            }
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var topLabel = ((sender as Label).Parent as StackLayout).Children.Where(x => x is Label).Where(y => (y as Label).Text.Contains("Топ")).FirstOrDefault() as Label;
            var itemsName = topLabel.Text.Split(' ')[1];

            await Navigation.PushAsync(new SelectTypePage(itemsName));
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SelectTypePage((sender as Button).Text.ToLower()));
        }

        private async void SearchBar_Focused(object sender, FocusEventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }
    }
}