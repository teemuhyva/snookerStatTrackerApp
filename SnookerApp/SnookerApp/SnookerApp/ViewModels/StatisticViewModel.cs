using SnookerApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace SnookerApp.ViewModels
{
    public class StatisticViewModel : INotifyPropertyChanged
    {
        double average;
        int potsSuccessPlayer1;
        int totalTriesPlayer1;

        private GameStatistics _gameStatistics { get; set; }

        public GameStatistics GameStatistics {
            get {
                return _gameStatistics;
            }
            set {
                _gameStatistics = value;
            }
        }        

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


        public StatisticViewModel(GameStatistics gameStatistics)
        {
            GameStatistics = gameStatistics;
        }
        //update statistic for player1
        public string PotsPlayer1 {
            get {
                return $"{average}% ({potsSuccessPlayer1}/{totalTriesPlayer1})";
            }
        }
        public string LongPlayer1 {
            get {
                return $"{average}% ({potsSuccessPlayer1}/{totalTriesPlayer1})";
            }
        }
        public string RestPlayer1 {
            get {
                return $"{average}% ({potsSuccessPlayer1}/{totalTriesPlayer1})";
            }
        }
        public string PsntPlayer1 {
            get {
                return $"{average}% ({potsSuccessPlayer1}/{totalTriesPlayer1})";
            }
        }
        public string SafetyPlayer1 {
            get {
                return $"{average}% ({potsSuccessPlayer1}/{totalTriesPlayer1})";
            }
        }
        public string ShotTimePlayer1 {
            get {
                return $"{average}% ({potsSuccessPlayer1}/{totalTriesPlayer1})";
            }
        }
        public string TableTimePlayer1 {
            get {
                return $"{average}% ({potsSuccessPlayer1}/{totalTriesPlayer1})";
            }
        }
        public string EscapePlayer1 {
            get {
                return $"{average}% ({potsSuccessPlayer1}/{totalTriesPlayer1})";
            }
        }

        //update statistic for player2
        public string PotsPlayer2 {
            get {
                return "{average}% ({potsSuccess} / {totalTries})";
            }
        }
        public string LongPlayer2 {
            get {
                return "{average}% ({potsSuccess} / {totalTries})";
            }
        }
        public string RestPlayer2 {
            get {
                return "{average}% ({potsSuccess} / {totalTries})";
            }
        }
        public string PsntPlayer2 {
            get {
                return "{average}% ({potsSuccess} / {totalTries})";
            }
        }
        public string SafetyPlayer2 {
            get {
                return "{average}% ({potsSuccess} / {totalTries})";
            }
        }
        public string ShotTimePlayer2 {
            get {
                return "{average}% ({potsSuccess} / {totalTries})";
            }
        }
        public string TableTimePlayer2 {
            get {
                return "{average}% ({potsSuccess} / {totalTries})";
            }
        }
        public string EscapePlayer2 {
            get {
                return "{average}% ({potsSuccess} / {totalTries})";
            }
        }
                
        public void CalculateAverage(int success, int total)
        {
            potsSuccessPlayer1 += success;
            totalTriesPlayer1 += total;
            average = Math.Floor(((double)success / total) * 100);
        }
    }
}
