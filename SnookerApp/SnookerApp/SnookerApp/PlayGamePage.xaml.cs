using SnookerApp.Model;
using SnookerApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SnookerApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PlayGamePage : ContentPage
	{
		public PlayGamePage ()
		{
			InitializeComponent ();
            BindingContext = new GamePageViewModel();
        }
        
        /*
        async void GoToStats(object sender, EventArgs e)  {
            await Navigation.PushAsync(new StatisticPage());
        }
        */
    }
}