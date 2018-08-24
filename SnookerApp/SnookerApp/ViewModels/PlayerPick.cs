using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SnookerApp.ViewModels
{
    public class PlayerPick : INotifyPropertyChanged
    {

        public PlayerPick() {
            GetNewPlayerCommand = new Command(GetNewPlayer);
        }
        string player1;
        string player2;

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public string Player1 {
            get {
                return player1;
            }
            set {
                if(player1 != value)
                {
                    player1 = value;
                }
                OnPropertyChanged();
            }
        }

        public string Player2 {
            get {
                return player2;
            }
            set {
                player2 = value;
                OnPropertyChanged();
            }
        }

        public Command GetNewPlayerCommand { get; }


        void GetNewPlayer()
        {
            Player1 = "Tuomas";
        }

    }
}
