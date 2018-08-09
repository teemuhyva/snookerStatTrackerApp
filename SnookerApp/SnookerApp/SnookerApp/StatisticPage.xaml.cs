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
        StatisticViewModel statisticViewModel;
        public StatisticPage ()
		{
			InitializeComponent ();
        }

        public StatisticPage(GameStatistics gameStatistics) 
        {
            InitializeComponent();
            statisticViewModel = new StatisticViewModel(gameStatistics);
            BindingContext = statisticViewModel;
        }

        async void BackToGamePage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PlayGamePage());
        }
    }
}