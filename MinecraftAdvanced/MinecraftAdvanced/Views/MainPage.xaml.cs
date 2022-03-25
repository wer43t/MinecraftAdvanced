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
        public List<Item> Tops { get; set; }
        public List<Item> TopBuildings { get; set; }
        public List<Item> TopMaps { get; set; }
        public List<Item> TopAddons { get; set; }
        public List<Item> TopTextures { get; set; }
        public List<Item> TopSeeds { get; set; }
        public List<string> Names { get; set; }
        public GoogleHelper helper = new GoogleHelper();
        public List<Button> Buttons { get; set; }

        public MainPage()
        {
            InitializeComponent();
            FillTops();

            this.BindingContext = this;
        }
        public void FillTops()
        {
            TopMaps = App.DataStorage["карты"].GetRange(0,5);
            TopBuildings = App.DataStorage["постройки"].GetRange(0, 5);
            TopAddons = App.DataStorage["аддоны"].GetRange(0, 5);
            TopTextures = App.DataStorage["текстуры"].GetRange(0, 5);
            TopSeeds = App.DataStorage["сиды"].GetRange(0, 5);
            Tops = new List<Item> { TopMaps[4], TopBuildings[4], TopAddons[4], TopTextures[4], TopSeeds[4] };
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

        private void Skins_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Отказано в доступе", "Страница недоступна", "Закрыть");
        }

        private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            await Navigation.PushAsync(new SelectedItemPage((sender as CollectionView).SelectedItem as Item));
        }
    }
}