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
        private double averagePotsPlayer1;
        private double averagePotsPlayer2;
        private double averageLongPlayer1;
        private double averageLongPlayer2;
        private double averageRestPlayer1;
        private double averageRestPlayer2;
        private int potsSuccessPlayer1;
        private int totalTriesPlayer1;
        private int potsSuccessPlayer2;
        private int totalTriesPlayer2;
        private int longSuccessPlayer1;
        private int longSuccessPlayer2;
        private int restSuccessPlayer1;
        private int restSuccessPlayer2;
        private Boolean isLongEnabled;
        private Boolean isRestEnabled;
        private Boolean Player1Turn;


        public GameStatisticViewModel(int successPlayer1, int totalPlayer1,
                                        int successPlayer2, int totalPlayer2, 
                                        Boolean isLong, Boolean isRest, Boolean isPlayer1Turn) {
            potsSuccessPlayer1 = successPlayer1;
            totalTriesPlayer1 = totalPlayer1;
            potsSuccessPlayer2 = successPlayer2;
            totalTriesPlayer2 = totalPlayer2;
            isLongEnabled = isLong;
            isRestEnabled = isRest;
            Player1Turn = isPlayer1Turn;
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
                return $"{averagePotsPlayer1}% ({potsSuccessPlayer1}/{totalTriesPlayer1})";
            }
        }

        public string LongPlayer1 {
            get {
                CalculateAverage(potsSuccessPlayer1, totalTriesPlayer1);
                return $"{averageLongPlayer1}% ({potsSuccessPlayer1}/{totalTriesPlayer1})";
            }
        }

        public string RestPlayer1 {
            get {
                CalculateAverage(potsSuccessPlayer1, totalTriesPlayer1);
                return $"{averageRestPlayer1}% ({potsSuccessPlayer1}/{totalTriesPlayer1})";
            }
        }

        public string PsntPlayer1 {
            get {
                return "";
            }
        }

        public string SafetyPlayer1 {
            get {
                return "";
            }
        }

        public string ShotTimePlayer1 {
            get {
                return "";
            }
        }

        public string TableTimePlayer1 {
            get {
                return "";
            }
        }

        public string EscapePlayer1 {
            get {
                return "";
            }
        }

        //update statistic for player2
        public string PotsPlayer2 {
            get {
                CalculateAverage(potsSuccessPlayer2, totalTriesPlayer2);
                return $"{averageLongPlayer2}% ({potsSuccessPlayer2}/{totalTriesPlayer2})";
            }
        }

        public string LongPlayer2 {
            get {
                CalculateAverage(potsSuccessPlayer2, totalTriesPlayer2);
                return $"{averagePotsPlayer2}% ({potsSuccessPlayer2}/{totalTriesPlayer2})";}% ({potsSuccessPlayer2}/{totalTriesPlayer2})";
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
            averagePotsPlayer1 = Math.Floor(((double)success / total) * 100);
        }    
    }
}
