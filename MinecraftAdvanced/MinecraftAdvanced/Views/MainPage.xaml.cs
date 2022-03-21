﻿using System;
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

            Buildings = App.DataStorage["постройки"].GetRange(0, 4);
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