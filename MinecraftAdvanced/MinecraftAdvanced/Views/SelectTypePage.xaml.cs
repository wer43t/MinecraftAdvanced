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
    public partial class SelectTypePage : TabbedPage
    {
        public SelectTypePage ()
        {
            InitializeComponent();
            Children.Add(new ItemsPage());
        }
    }
}