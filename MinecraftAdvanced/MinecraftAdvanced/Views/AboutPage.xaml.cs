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
        public List<Monkey> Monkeys { get; set; }
        public List<string> Names { get; set; }
        public GoogleHelper helper = new GoogleHelper();
        public AboutPage()
        {
            InitializeComponent();
            Monkeys = new List<Monkey>();
            Monkeys.Add(new Monkey() 
            { 
                Name = "Andrew", 
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/43/Bonnet_macaque_%28Macaca_radiata%29_Photograph_By_Shantanu_Kuveskar.jpg/220px-Bonnet_macaque_%28Macaca_radiata%29_Photograph_By_Shantanu_Kuveskar.jpg",
                Location = "Kazan",
                Details = "Bozin"
            }
            );
            Monkeys.Add(new Monkey()
            {
                Name = "Andrew",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/43/Bonnet_macaque_%28Macaca_radiata%29_Photograph_By_Shantanu_Kuveskar.jpg/220px-Bonnet_macaque_%28Macaca_radiata%29_Photograph_By_Shantanu_Kuveskar.jpg",
                Location = "Kazan",
                Details = "Bozin"
            }
            );
            Names = helper.ReadNames();

            this.BindingContext = this;
        }
    }
    public class Monkey
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Location { get; set; }
        public string Details { get; set; }
    }
}