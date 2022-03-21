using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MinecraftAdvanced.Models;

namespace MinecraftAdvanced.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectedItemPage : ContentPage
    {
        public GoogleHelper helper;
        public Item SelectedItem { get; set; }
        public SelectedItemPage(Item selectedItem)
        {
            helper = new GoogleHelper();
            SelectedItem = selectedItem;
            InitializeComponent();
            BindingContext = SelectedItem;

            FavouriteItem favourite = new FavouriteItem(SelectedItem);
            if (!helper.GetFavourites().Where(f => f.Id == favourite.Id).Any())
            {
                //helper.DeleteFavourite(favourite);
                btnLike.Text = "\ue87e";
                btnLike.TextColor = Color.White;
            }
            else
            {
                //helper.PostFavourite(favourite);
                btnLike.Text = "\ue87d";
                btnLike.TextColor = Color.Red;
            }
        }

        private void btnLike_Clicked(object sender, EventArgs e)
        {
            FavouriteItem favourite = new FavouriteItem(SelectedItem);


            if (helper.GetFavourites().Where(f => f.Id == favourite.Id).Any())
            {
                helper.DeleteFavourite(favourite);
                btnLike.Text = "\ue87e";
                btnLike.TextColor = Color.White;
            }
            else
            {
                helper.PostFavourite(favourite);
                btnLike.Text = "\ue87d";
                btnLike.TextColor = Color.Red;
            }

            //if (!App.Database.IsProjectFavourite(project))
            //{
            //    App.Database.InsertFavourite(project);
            //    iconFavourite.IconImageSource = new FontImageSource() { Glyph = "\ue838", Color = Color.Yellow, FontFamily = "MaterialIconsFont" };
            //}
            //else
            //{
            //    App.Database.DeleteFavourite(project);
            //    iconFavourite.IconImageSource = new FontImageSource() { Glyph = "\ue83a", Color = Color.White, FontFamily = "MaterialIconsFont" };
            //}
        }
    }
}