using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;
using MinecraftAdvanced;

namespace MinecraftAdvanced.Views
{
    public partial class AboutPage : ContentPage
    {
        public string[] sheetNames = new string[] { "mods_catalog", "maps_catalog" };
        public List<Building> Buildings { get; set; }
        public List<string> Names { get; set; }
        public GoogleHelper helper = new GoogleHelper();
        public List<Button> Buttons { get; set; }

        public AboutPage()
        {
            InitializeComponent();

            Buildings = helper.GetBuildings().GetRange(0, 4);
            FillTops();

            this.BindingContext = this;
        }
        public void FillTops()
        {
            foreach (var building in Buildings)
            {
                MapsLayout.Children.Add(new Image() { Source = building.Image });
            }
            foreach (var building in Buildings)
            {
                BuildingsLayout.Children.Add(new Image() { Source = building.Image });
            }
            foreach (var building in Buildings)
            {
                AddonsLayout.Children.Add(new Image() { Source = building.Image });
            }
            foreach (var building in Buildings)
            {
                TexturesLayout.Children.Add(new Image() { Source = building.Image });
            }
            foreach (var building in Buildings)
            {
                SkinsLayout.Children.Add(new Image() { Source = building.Image });
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            DisplayAlert("Ты","Тыкнул", "Да");
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SelectTypePage());
        }
    }
}