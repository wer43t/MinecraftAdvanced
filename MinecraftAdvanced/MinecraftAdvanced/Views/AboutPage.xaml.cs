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
        public List<Building> Buildings { get; set; }
        public List<string> Names { get; set; }
        public GoogleHelper helper = new GoogleHelper();
        public List<Button> Buttons { get; set; }

        public AboutPage()
        {
            InitializeComponent();
            Buildings = helper.GetBuildings().GetRange(0, 4);
            


            this.BindingContext = this;
        }
        public void PrepareButtons()
        {
            
        }
    }
}