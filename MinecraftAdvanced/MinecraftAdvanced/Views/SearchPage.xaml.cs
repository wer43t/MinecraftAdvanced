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
        public SearchPage()
        {
            InitializeComponent();
            previusBtn = mapsBtn;
            previusBtn.BackgroundColor = Color.Red;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            previusBtn.BackgroundColor = Color.FromHex("#4DAAF4");
            previusBtn = (sender as Button);
            (sender as Button).BackgroundColor = Color.Red;
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            DisplayAlert("Салават не сделал", "я дебил", "ультрамегахорош");
        }
    }


}