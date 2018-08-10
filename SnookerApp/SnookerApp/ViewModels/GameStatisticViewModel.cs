using SnookerApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace SnookerApp.ViewModels
{
    public class GameStatisticViewModel : INotifyPropertyChanged
    {
        double average;
        int potsSuccessPlayer1;
        int totalTriesPlayer1;
               

        public GameStatisticViewModel(int success, int total)
        {
            potsSuccessPlayer1 = success;
            totalTriesPlayer1 = total;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }       

        //update statistic for player1
        public string PotsPlayer1 {
            get {
                CalculateAverage(potsSuccessPlayer1, totalTriesPlayer1);
                return $"{average}% ({potsSuccessPlayer1}/{totalTriesPlayer1})";
            }
        }
        public string LongPlayer1 {
            get {
                CalculateAverage(potsSuccessPlayer1, totalTriesPlayer1);
                return $"{average}% ({potsSuccessPlayer1}/{totalTriesPlayer1})";
            }
        }
        public string RestPlayer1 {
            get {
                CalculateAverage(potsSuccessPlayer1, totalTriesPlayer1);
                return $"{average}% ({potsSuccessPlayer1}/{totalTriesPlayer1})";
            }
        }
        public string PsntPlayer1 {
            get {
                CalculateAverage(potsSuccessPlayer1, totalTriesPlayer1);
                return $"{average}% ({potsSuccessPlayer1}/{totalTriesPlayer1})";
            }
        }
        public string SafetyPlayer1 {
            get {
                CalculateAverage(potsSuccessPlayer1, totalTriesPlayer1);
                return $"{average}% ({potsSuccessPlayer1}/{totalTriesPlayer1})";
            }
        }
        public string ShotTimePlayer1 {
            get {
                CalculateAverage(potsSuccessPlayer1, totalTriesPlayer1);
                return $"{average}% ({potsSuccessPlayer1}/{totalTriesPlayer1})";
            }
        }
        public string TableTimePlayer1 {
            get {
                CalculateAverage(potsSuccessPlayer1, totalTriesPlayer1);
                return $"{average}% ({potsSuccessPlayer1}/{totalTriesPlayer1})";
            }
        }
        public string EscapePlayer1 {
            get {
                CalculateAverage(potsSuccessPlayer1, totalTriesPlayer1);
                return $"{average}% ({potsSuccessPlayer1}/{totalTriesPlayer1})";
            }
        }

        //update statistic for player2
        public string PotsPlayer2 {
            get {
                CalculateAverage(potsSuccessPlayer1, totalTriesPlayer1);
                return $"{average}% ({potsSuccessPlayer1}/{totalTriesPlayer1})";
            }
        }
        public string LongPlayer2 {
            get {
                CalculateAverage(potsSuccessPlayer1, totalTriesPlayer1);
                return $"{average}% ({potsSuccessPlayer1}/{totalTriesPlayer1})";
            }
        }
        public string RestPlayer2 {
            get {
                CalculateAverage(potsSuccessPlayer1, totalTriesPlayer1);
                return $"{average}% ({potsSuccessPlayer1}/{totalTriesPlayer1})";
            }
        }
        public string PsntPlayer2 {
            get {
                CalculateAverage(potsSuccessPlayer1, totalTriesPlayer1);
                return $"{average}% ({potsSuccessPlayer1}/{totalTriesPlayer1})";
            }
        }
        public string SafetyPlayer2 {
            get {
                CalculateAverage(potsSuccessPlayer1, totalTriesPlayer1);
                return $"{average}% ({potsSuccessPlayer1}/{totalTriesPlayer1})";
            }
        }
        public string ShotTimePlayer2 {
            get {
                CalculateAverage(potsSuccessPlayer1, totalTriesPlayer1);
                return $"{average}% ({potsSuccessPlayer1}/{totalTriesPlayer1})";
            }
        }
        public string TableTimePlayer2 {
            get {
                CalculateAverage(potsSuccessPlayer1, totalTriesPlayer1);
                return $"{average}% ({potsSuccessPlayer1}/{totalTriesPlayer1})";
            }
        }
        public string EscapePlayer2 {
            get {
                CalculateAverage(potsSuccessPlayer1, totalTriesPlayer1);
                return $"{average}% ({potsSuccessPlayer1}/{totalTriesPlayer1})";
            }
        }
                
        public void CalculateAverage(int success, int total)
        {
            average = Math.Floor(((double)success / total) * 100);
        }
    }
}
