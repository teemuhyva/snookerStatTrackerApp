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
        
        public StatisticPage (int potsSuccessPlayer1, int totalTriesPlayer1,
            int potsSuccessPlayer2, int totalTriesPlayer2,
            int longSuccess1, int longTotal1,
            int longSuccess2, int longTotal2,
            int restSuccess1, int restTotal1,
            int restSuccess2, int restTotal2,
            Boolean isPlayer1Turn)
		{

            InitializeComponent ();
            BindingContext = new GameStatisticViewModel(potsSuccessPlayer1, totalTriesPlayer1, 
                potsSuccessPlayer2, totalTriesPlayer2,
                longSuccess1, longTotal1,
                longSuccess2, longTotal2,
                restSuccess1, restTotal1,
                restSuccess2, restTotal2,
                isPlayer1Turn);
        }
        
        async void BackToGamePage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PlayGamePage());
        }
    }
}