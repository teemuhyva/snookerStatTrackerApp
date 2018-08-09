using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace SnookerApp.Model
{
    public class GameStatistics : INotifyPropertyChanged
    {

        private int potsSuccessPlayer1;
        private int totalTriesPlayer1;


        public GameStatistics() { }
        public GameStatistics(int potsSuccess, int totalTries)
        {
            potsSuccessPlayer1 = potsSuccess;

            totalTriesPlayer1 = totalTries;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public int PotsSuccessPlayer1 {
            get {
                return potsSuccessPlayer1; 
            }
            set {
                potsSuccessPlayer1 = value;
                OnPropertyChanged();
            }
        }
        public int TotalTriesPlayer1 {
            get {
                return totalTriesPlayer1;
            }
            set {
                potsSuccessPlayer1 = value;
                OnPropertyChanged();
            }
        }
    }
}
