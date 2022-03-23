﻿using MinecraftAdvanced.Services;
using MinecraftAdvanced.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;
using MinecraftAdvanced.Models;

[assembly: ExportFont("MaterialIcons-Regular.ttf", Alias = "IconsFont")]
namespace MinecraftAdvanced
{
    public partial class App : Application
    {
        public GoogleHelper helper;
        public static Dictionary<string, List<Item>> DataStorage = new Dictionary<string, List<Item>>
        {
            {"карты",     new List<Item>()},
            {"аддоны",    new List<Item>()},
            {"текстуры",  new List<Item>()},
            {"постройки", new List<Item>()},
            {"сиды",      new List<Item>()}
        };
        public static Dictionary<string, string> sheetNames = new Dictionary<string, string>
        {
            {"карты",       "maps_catalog"},
            {"аддоны",      "mods_catalog"},
            {"текстуры",    "textures_catalog"},
            {"постройки",   "buildings_catalog"},
            {"сиды",        "seeds_catalog"}
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
