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
	public partial class StatisticPage : ContentPage
	{
        
        public StatisticPage (int success, int total)
		{
			InitializeComponent ();
            BindingContext = new GameStatisticViewModel(success, total);
        }
        
        async void BackToGamePage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PlayGamePage());
        }
    }
}