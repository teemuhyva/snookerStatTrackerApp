using SnookerApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SnookerApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PlaySetGame2 : ContentPage
	{
        public PlaySetGame2()
        {
            InitializeComponent();

            BindingContext = new PlayerPick();

            playerView.ItemsSource = Players.PlayerList;
        }

        async void SetHandiCapPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PlaySetGame3());
        }
        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            PlayerPick playerPick = new PlayerPick();
            if(e.SelectedItem != null)
            {
                var selection = e.SelectedItem as Players;
                playerPick.Player1 = selection.PlayerName;
            }
        }
        
        
    }
}