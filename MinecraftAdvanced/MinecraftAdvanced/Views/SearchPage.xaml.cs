using MinecraftAdvanced.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MinecraftAdvanced.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {
        Button previusBtn;
        string filter = "none";
        public List<Item> Items { get; set; }
        public SearchPage()
        {
            InitializeComponent();
            previusBtn = mapsBtn;
            previusBtn.BackgroundColor = Color.FromHex("#5AA660");
            filter = previusBtn.Text;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            previusBtn.BackgroundColor = Color.FromHex("#4DAAF4");
            previusBtn = (sender as Button);
            filter = (sender as Button).Text;
            (sender as Button).BackgroundColor = Color.FromHex("#5AA660");
            lvItems.ItemsSource = null;
            
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            DisplayAlert("Салават не сделал", "я дебил", "ультрамегахорош");
        }

        private async void lvItems_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new SelectedItemPage(lvItems.SelectedItem as Item));
        }

        private void searchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            IEnumerable<Item> tempItem = App.DataStorage[filter];
            Items = tempItem.Where(x => x.Title.ToLower().Contains(searchBar.Text.ToLower())).ToList();
            if (Items.Count == 0)
            {
                DisplayAlert("Поиск", "Ничего не найдено", "Ок");
                return;
            }
            lvItems.ItemsSource = Items;
        }
    }


}