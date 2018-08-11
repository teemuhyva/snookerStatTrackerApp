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
        private int potsSuccessPlayer1, totalTriesPlayer1, longSuccessPlayer1, longTotalPlayer1, restSuccessPlayer1, restTotalPlayer1;
        private int potsSuccessPlayer1temp, totalTriesPlayer1temp, longSuccessPlayer1temp, longTotalPlayer1temp, restSuccessPlayer1temp, restTotalPlayer1temp;
        private int potsSuccessPlayer2, totalTriesPlayer2, longSuccessPlayer2, longTotalPlayer2, restSuccessPlayer2, restTotalPlayer2;
        private int potsSuccessPlayer2temp, totalTriesPlayer2temp, longSucces2Player1temp, longTotalPlayer2temp, restSuccessPlayer2temp, restTotalPlayer2temp;

        private Boolean isLongEnabled;
        private Boolean isRestEnabled;
        private Boolean Player1Turn;

        private string calculateAverageFor;

        GameStatistics gameStatistics;

        public GameStatisticViewModel(int successPlayer1, int totalPlayer1,
                                        int successPlayer2, int totalPlayer2,
                                        int longSuccess1, int longTotal1,
                                        int longSuccess2, int longTotal2,
                                        int restSuccess1, int restTotal1,
                                        int restSuccess2, int restTotal2,
                                         Boolean isPlayer1Turn) {
            potsSuccessPlayer1 = successPlayer1;
            totalTriesPlayer1 = totalPlayer1;
            potsSuccessPlayer2 = successPlayer2;
            totalTriesPlayer2 = totalPlayer2;
            longSuccessPlayer1 = longSuccess1;
            longTotalPlayer1 = longTotal1;
            longSuccessPlayer2 = longSuccess2;
            longTotalPlayer1 = longTotal2;
            restSuccessPlayer1 = restSuccess1;
            restTotalPlayer1 = restTotal1;
            restSuccessPlayer2 = restSuccess2;
            restTotalPlayer2 = restTotal2;
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
                if(Player1Turn) {
                    calculateAverageFor = "potsPlayer1";
                    CalculateAverage(potsSuccessPlayer1temp, totalTriesPlayer1temp);
                }
                
                return $"{averagePotsPlayer1}% ({potsSuccessPlayer1temp}/{totalTriesPlayer1temp})";
            }
        }

        public string LongPlayer1 {
            get {
                if(Player1Turn) {
                    calculateAverageFor = "longPlayer1";
                    CalculateAverage(longSuccessPlayer1, longTotalPlayer1);
                }               
               
                return $"{averageLongPlayer1}% ({longSuccessPlayer1}/{longTotalPlayer1})";
            }
        }

        public string RestPlayer1 {
            get {
                if(Player1Turn) {
                    calculateAverageFor = "restPlayer1";
                    CalculateAverage(restSuccessPlayer1, restTotalPlayer1);
                }               
                
                return $"{averageRestPlayer1}% ({restSuccessPlayer1}/{restTotalPlayer1})";
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
                if(!Player1Turn) {
                    calculateAverageFor = "potsPlayer2";
                    CalculateAverage(potsSuccessPlayer2, totalTriesPlayer2);
                    
                }
                return $"{averagePotsPlayer2}% ({potsSuccessPlayer2}/{totalTriesPlayer2})";
            }
        }

        public string LongPlayer2 {
            get {
                if(!Player1Turn) {
                    calculateAverageFor = "longPlayer2";
                    CalculateAverage(longSuccessPlayer2, longTotalPlayer2);
                }
                                
                return $"{averagePotsPlayer2}% ({longSuccessPlayer2}/{longTotalPlayer2})";
            }
        }
        public string RestPlayer2 {
            get {
                if(!Player1Turn) {
                    calculateAverageFor = "restPlayer2";
                    CalculateAverage(restSuccessPlayer2, restTotalPlayer2);
                }
                
                return $"{averageRestPlayer1}% ({restSuccessPlayer2}/{restTotalPlayer2})";
            }
        }
        public void CalculateAverage(int success, int total)
        {
            if(calculateAverageFor.Equals("potsPlayer1")) {
                averagePotsPlayer1 = Math.Floor(((double)success / total) * 100);
            } else if(calculateAverageFor.Equals("longPlayer1")) {
                averageLongPlayer1 = Math.Floor(((double)success / total) * 100);
            } else if(calculateAverageFor.Equals("restPlayer1")) {
                averageRestPlayer1 = Math.Floor(((double)success / total) * 100);
            } else if(calculateAverageFor.Equals("potsPlayer2")) {
                averagePotsPlayer2 = Math.Floor(((double)success / total) * 100);
            } else if (calculateAverageFor.Equals("longPlayer2")) {
                averageLongPlayer2 = Math.Floor(((double)success / total) * 100);
            } else if (calculateAverageFor.Equals("restPlayer2")) {
                averageRestPlayer2 = Math.Floor(((double)success / total) * 100);
            }        
        }

    }
}
