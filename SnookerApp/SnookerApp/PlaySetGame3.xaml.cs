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
	public partial class PlaySetGame3 : ContentPage
	{
		public PlaySetGame3 ()
		{
			InitializeComponent ();

            BindingContext = new LenghtPlayPickerViewModel();
        }

        async void PlayGame(object sender, EventArgs e)
        {
            var playGamePage = new PlayGamePage();
            NavigationPage.SetHasNavigationBar(playGamePage, false);
            await Navigation.PushAsync(playGamePage);
           
        }

        async void BackToSetGame2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PlaySetGame2());
        }
    }
}