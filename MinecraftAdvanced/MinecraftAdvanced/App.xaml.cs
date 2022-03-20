using MinecraftAdvanced.Services;
using MinecraftAdvanced.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;
using MinecraftAdvanced.Models;

namespace MinecraftAdvanced
{
    public partial class App : Application
    {
        public GoogleHelper helper;
        public static Dictionary<string, List<Item>> DataStorage = new Dictionary<string, List<Item>>
        {
            {"Карты",     new List<Item>()},
            {"Аддоны",    new List<Item>()},
            {"Текстуры",  new List<Item>()},
            {"Постройки", new List<Item>()},
            {"Скины",     new List<Item>()},
            {"Сиды",      new List<Item>()}
        };
        public static Dictionary<string, string> sheetNames = new Dictionary<string, string>
        {
            {"Карты",       "maps_catalog"},
            {"Аддоны",      ""},
            {"Текстуры",    "textures_catalog"},
            {"Постройки",   "buildings_catalog"},
            {"Скины",       ""},
            {"Сиды",        ""}
        };
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            helper = new GoogleHelper();

            foreach (var key in sheetNames.Keys)
            {
                DataStorage[key] = helper.GetItems(sheetNames[key]);
            }
        }

        protected override void OnStart()
        {
            
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
