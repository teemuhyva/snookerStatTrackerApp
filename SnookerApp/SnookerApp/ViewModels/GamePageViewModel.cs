﻿using SnookerApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SnookerApp.ViewModels
{
    public class GamePageViewModel : INotifyPropertyChanged
    {
        private int player1Score, player2Score, player1Break, player2Break;

        private int totalPointsInGame = 147;
        private int currentPointsGained, currentAmountRedPotted;
        private string gameTextArea, gameScoreArea;
        private string playerStatsDisplayText;

        private double average;
        private int potsSuccessPlayer1, totalTriesPlayer1, longSuccess1, longTotal1, restSuccess1, restTotal1;
        private int potsSuccessPlayer2, totalTriesPlayer2, longSuccess2, longTotal2, restSuccess2, restTotal2;
        private Boolean isPlayer1Turn;
        private Boolean isRest;
        private Boolean isLong;

        private Boolean yellow = false;
        private Boolean green = false;
        private Boolean blue = false;
        private Boolean brown = false;
        private Boolean pink = false;
        private Boolean black = false;

        private INavigation _navigation;

        //if red is false player can pot colored ball
        Boolean red = true;

        Boolean player1Turn = true;
        
        public GamePageViewModel(INavigation navigation)
        {
            _navigation = navigation;
            AddOnePoint = new Command(OnePoint);
            AddTwoPoint = new Command(TwoPoint);
            AddThreePoint = new Command(ThreePoint);
            AddFourPoint = new Command(FourPoint);
            AddFivePoint = new Command(FivePoint);
            AddSixPoint = new Command(SixPoint);
            AddSevenPoint = new Command(SevenPoint);
            MissedPot = new Command(PotMissed);
            GoToStats = new Command<object>(CheckStats);
            Rest = new Command(RestEnabled);
            Long = new Command(LongEnabled);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public Command<object> GoToStats { get; set; }       

        //update scores
        public int Player1Score {
            get {
                return player1Score;
            }
            set {
                player1Score += value;
                OnPropertyChanged();
            }
        }
        public int Player1Break {
            get {
                return player1Break;
            }
            set {
                player1Break += value;
                OnPropertyChanged();
            }
        }
        public int Player2Score {
            get {
                return player2Score;
            }
            set {
                player2Score += value;
                OnPropertyChanged();
            }
        }
        public int Player2Break {
            get {
                return player2Break;
            }
            set {
                player2Break += value;     
                OnPropertyChanged();
            }
        }
        public int PotsSuccessPlayer1 {
            get {
                return potsSuccessPlayer1;
            } 
            set {
                potsSuccessPlayer1 += 1;
                OnPropertyChanged();
            }
        }
        public int TotalTriesPlayer1 {
            get {
                return totalTriesPlayer1;
            }
            set {
                totalTriesPlayer1 += 1;
                OnPropertyChanged();
            }
        }
        public int PotsSuccessPlayer2 {
            get {
                return potsSuccessPlayer2;
            }
            set {
                potsSuccessPlayer2 += 1;
                OnPropertyChanged();
            }
        }
        public int TotalTriesPlayer2 {
            get {
                return totalTriesPlayer2;
            }
            set {
                totalTriesPlayer2 += 1;
                OnPropertyChanged();
            }
        }
        public string GameTextArea {
            get {
                return gameTextArea;
            }
            set {
                gameTextArea += value;
            }
        }

       

        public Command AddOnePoint { get; }
        public Command AddTwoPoint { get; }
        public Command AddThreePoint { get; }
        public Command AddFourPoint { get; }
        public Command AddFivePoint { get; }
        public Command AddSixPoint { get; }
        public Command AddSevenPoint { get; }
        public Command MissedPot { get; }
        public Command Long { get; }
        public Command Rest { get; }

        //these following 7 methods for points needs to be refactored. Does same things over and over again
        //logic is ok for now.
        void OnePoint()
        {
            if (currentAmountRedPotted < 15 || totalPointsInGame < 147)
            {
                if (player1Turn)
                {
                    currentPointsGained += 1;
                    currentAmountRedPotted += 1;
                    potsSuccessPlayer1++;
                    totalTriesPlayer1++;
                    GameTextArea = "Player 1 scored 1 point\n";
                    Player1Score = 1;
                    Player1Break = 1;                    
                    red = false;
                    
                    if(isLong)
                    {
                        longSuccess1++;
                        longTotal1++;
                        isLong = false;
                    }

                    if(isRest)
                    {
                        restSuccess1++;
                        restTotal1++;
                        isRest = false;
                    }
                }
                else
                {
                    GameTextArea = "Player 2 scored 1 point\n";
                    currentPointsGained += 1;
                    currentAmountRedPotted += 1;
                    potsSuccessPlayer2++;
                    totalTriesPlayer2++;
                    Player2Score = 1;
                    Player2Break = 1;                    
                    red = false;

                    if (isLong)
                    {
                        longSuccess2++;
                        longTotal2++;
                        isLong = false;
                    }

                    if (isRest)
                    {
                        restSuccess2++;
                        restTotal2++;
                        isRest = false;
                    }
                }
            }
            else
            {
                if (currentPointsGained == totalPointsInGame)
                {
                    GameTextArea = "No more points possible\n";
                }
                if (currentAmountRedPotted == 15)
                {
                    GameTextArea = "No more red balls on table. Next possible Yellow\n";
                }
            }                       
        }
        void TwoPoint()
        {
            if (currentAmountRedPotted < 15) {
                //just quick fix if player can pot colored ball.
                //needs refactoring and also if player will pot color instead of red it will be foul
                //TODO: create foul page
                //this is for all colored
                if(!red)
                {
                    if (player1Turn)
                    {
                        potsSuccessPlayer1++;
                        totalTriesPlayer1++;
                        currentPointsGained += 2;
                        Player1Score = 2;
                        Player1Break = 2;                        
                        GameTextArea = "Player 1 scored 2 points\n";                        
                        red = true;

                        if (isLong)
                        {
                            longSuccess1++;
                            longTotal1++;
                            isLong = false;
                        }

                        if (isRest)
                        {
                            restSuccess1++;
                            restTotal1++;
                            isRest = false;
                        }
                    }
                    else
                    {
                        potsSuccessPlayer2++;
                        totalTriesPlayer2++;
                        currentPointsGained += 2;
                        Player2Score = 2;
                        Player2Break = 2;                        
                        GameTextArea = "Player 2 scored 2 points\n";                        
                        red = true;

                        if (isLong)
                        {
                            longSuccess2++;
                            longTotal2++;
                            isLong = false;
                        }

                        if (isRest)
                        {
                            restSuccess2++;
                            restTotal2++;
                            isRest = false;
                        }
                    }
                }
               
            } else {
                if(currentAmountRedPotted == 15) {
                    if(!yellow)
                    {
                        if(player1Turn)
                        {
                            Player1Score = 2;
                            Player1Break = 2;
                            currentPointsGained += 2;
                            yellow = true;

                            if (isLong)
                            {
                                longSuccess1++;
                                longTotal1++;
                                isLong = false;
                            }

                            if (isRest)
                            {
                                restSuccess1++;
                                restTotal1++;
                                isRest = false;
                            }
                        } else
                        {
                            Player2Score = 2;
                            Player2Break = 2;
                            currentPointsGained += 2;
                            yellow = true;

                            if (isLong)
                            {
                                longSuccess2++;
                                longTotal2++;
                                isLong = false;
                            }

                            if (isRest)
                            {
                                restSuccess2++;
                                restTotal2++;
                                isRest = false;
                            }
                        }
                       
                    }
                }

                if (currentPointsGained == totalPointsInGame)
                {
                    GameTextArea = "Total points gained";
                }
            }
           
        }
        void ThreePoint()
        {
            if (currentAmountRedPotted < 15)
            {
                if(!red)
                {
                    if (player1Turn)
                    {
                        potsSuccessPlayer1++;
                        totalTriesPlayer1++;
                        currentPointsGained += 3;
                        Player1Score = 3;
                        Player1Break = 3;                        
                        GameTextArea = "Player 1 scored 3 points\n";                        
                        red = true;

                        if (isLong)
                        {
                            longSuccess1++;
                            longTotal1++;
                            isLong = false;
                        }

                        if (isRest)
                        {
                            restSuccess1++;
                            restTotal1++;
                            isRest = false;
                        }
                    }
                    else
                    {
                        potsSuccessPlayer2++;
                        totalTriesPlayer2++;
                        currentPointsGained += 3;
                        Player2Score = 3;
                        Player2Break = 3;                        
                        GameTextArea = "Player 2 scored 3 points\n";                        
                        red = true;

                        if (isLong)
                        {
                            longSuccess2++;
                            longTotal2++;
                            isLong = false;
                        }

                        if (isRest)
                        {
                            restSuccess2++;
                            restTotal2++;
                            isRest = false;
                        }
                    }
                }
                
            }
            else
            {
                if (currentAmountRedPotted == 15)
                {
                    if (!green)
                    {
                        if(player1Turn)
                        {
                            Player1Score = 3;
                            Player1Break = 3;
                            currentPointsGained += 3;
                            green = true;

                            if (isLong)
                            {
                                longSuccess1++;
                                longTotal1++;
                                isLong = false;
                            }

                            if (isRest)
                            {
                                restSuccess1++;
                                restTotal1++;
                                isRest = false;
                            }
                        } else
                        {
                            Player2Score = 3;
                            Player2Break = 3;
                            currentPointsGained += 3;
                            green = true;

                            if (isLong)
                            {
                                longSuccess2++;
                                longTotal2++;
                                isLong = false;
                            }

                            if (isRest)
                            {
                                restSuccess2++;
                                restTotal2++;
                                isRest = false;
                            }
                        }
                      
                    }
                }

                if (currentPointsGained == totalPointsInGame)
                {
                    GameTextArea = "Total points gained";
                }
            }

        }
        void FourPoint()
        {
            if (currentAmountRedPotted < 15)
            {
                if(!red)
                {
                    if (player1Turn)
                    {
                        potsSuccessPlayer1++;
                        totalTriesPlayer1++;
                        currentPointsGained += 4;
                        Player1Score = 4;
                        Player1Break = 4;                        
                        GameTextArea = "Player 1 scored 4 points\n";
                        
                        red = true;
                        if (isLong)
                        {
                            longSuccess1++;
                            longTotal1++;
                            isLong = false;
                        }

                        if (isRest)
                        {
                            restSuccess1++;
                            restTotal1++;
                            isRest = false;
                        }
                    }
                    else
                    {
                        potsSuccessPlayer2++;
                        totalTriesPlayer2++;
                        currentPointsGained += 4;
                        Player2Score = 4;
                        Player2Break = 4;                        
                        GameTextArea = "Player 2 scored 4 points\n";                        
                        red = true;

                        if (isLong)
                        {
                            longSuccess2++;
                            longTotal2++;
                            isLong = false;
                        }

                        if (isRest)
                        {
                            restSuccess2++;
                            restTotal2++;
                            isRest = false;
                        }
                    }
                }
               
            }
            else
            {
                if (currentAmountRedPotted == 15)
                {
                    if (!blue)
                    {
                        if(player1Turn)
                        {
                            Player1Score = 4;
                            Player1Break = 4;
                            currentPointsGained += 4;
                            blue = true;

                            if (isLong)
                            {
                                longSuccess1++;
                                longTotal1++;
                                isLong = false;
                            }

                            if (isRest)
                            {
                                restSuccess1++;
                                restTotal1++;
                                isRest = false;
                            }
                        } else
                        {
                            Player2Score = 4;
                            Player2Break = 4;
                            currentPointsGained += 4;
                            blue = true;

                            if (isLong)
                            {
                                longSuccess2++;
                                longTotal2++;
                                isLong = false;
                            }

                            if (isRest)
                            {
                                restSuccess2++;
                                restTotal2++;
                                isRest = false;
                            }
                        }
                        
                    }
                }

                if (currentPointsGained == totalPointsInGame)
                {
                    GameTextArea = "Total points gained";
                }
            }

        }
        void FivePoint()
        {
            if (currentAmountRedPotted < 15)
            {
                if(!red)
                {
                    if (player1Turn)
                    {
                        potsSuccessPlayer1++;
                        totalTriesPlayer1++;
                        currentPointsGained += 5;
                        Player1Score = 5;
                        Player1Break = 5;                        
                        GameTextArea = "Player 1 scored 5 points\n";                        
                        red = true;

                        if (isLong)
                        {
                            longSuccess1++;
                            longTotal1++;
                            isLong = false;
                        }

                        if (isRest)
                        {
                            restSuccess1++;
                            restTotal1++;
                            isRest = false;
                        }
                    }
                    else
                    {
                        Player2Score = 5;
                        Player2Break = 5;
                        currentPointsGained += 5;
                        GameTextArea = "Player 2 scored 5 points\n";
                        potsSuccessPlayer2++;
                        totalTriesPlayer2++;
                        red = true;

                        if (isLong)
                        {
                            longSuccess2++;
                            longTotal2++;
                            isLong = false;
                        }

                        if (isRest)
                        {
                            restSuccess2++;
                            restTotal2++;
                            isRest = false;
                        }
                    }
                }
               
            }
            else
            {
                if (currentAmountRedPotted == 15)
                {
                    if (!brown)
                    {
                        if(player1Turn)
                        {
                            Player1Score = 5;
                            Player1Break = 5;
                            currentPointsGained += 5;
                            brown = true;

                            if (isLong)
                            {
                                longSuccess1++;
                                longTotal1++;
                                isLong = false;
                            }

                            if (isRest)
                            {
                                restSuccess1++;
                                restTotal1++;
                                isRest = false;
                            }
                        } else
                        {
                            Player2Score = 5;
                            Player2Break = 5;
                            currentPointsGained += 5;
                            brown = true;

                            if (isLong)
                            {
                                longSuccess2++;
                                longTotal2++;
                                isLong = false;
                            }

                            if (isRest)
                            {
                                restSuccess2++;
                                restTotal2++;
                                isRest = false;
                            }
                        }
                        
                    }
                }

                if (currentPointsGained == totalPointsInGame)
                {
                    GameTextArea = "Total points gained";
                }
            }

        }
        void SixPoint()
        {
            if (currentAmountRedPotted < 15)
            {
                if(!red)
                {
                    if (player1Turn)
                    {
                        potsSuccessPlayer1++;
                        totalTriesPlayer1++;
                        currentPointsGained += 6;
                        Player1Score = 6;
                        Player1Break = 6;                        
                        GameTextArea = "Player 1 scored 6 points\n";                        
                        red = true;

                        if (isLong)
                        {
                            longSuccess1++;
                            longTotal1++;
                            isLong = false;
                        }

                        if (isRest)
                        {
                            restSuccess1++;
                            restTotal1++;
                            isRest = false;
                        }
                    }
                    else
                    {
                        potsSuccessPlayer2++;
                        totalTriesPlayer2++;
                        currentPointsGained += 6;
                        Player2Score = 6;
                        Player2Break = 6;                        
                        GameTextArea = "Player 2 scored 6 points\n";                        
                        red = true;

                        if (isLong)
                        {
                            longSuccess2++;
                            longTotal2++;
                            isLong = false;
                        }

                        if (isRest)
                        {
                            restSuccess2++;
                            restTotal2++;
                            isRest = false;
                        }
                    }
                }
                
            }
            else
            {
                if (currentAmountRedPotted == 15)
                {
                    if (!pink)
                    {
                        if(player1Turn)
                        {
                            Player1Score = 6;
                            Player1Break = 6;
                            currentPointsGained += 6;
                            pink = true;

                            if (isLong)
                            {
                                longSuccess1++;
                                longTotal1++;
                                isLong = false;
                            }

                            if (isRest)
                            {
                                restSuccess1++;
                                restTotal1++;
                                isRest = false;
                            }
                        } else
                        {
                            Player2Score = 6;
                            Player2Break = 6;
                            currentPointsGained += 6;
                            pink = true;

                            if (isLong)
                            {
                                longSuccess2++;
                                longTotal2++;
                                isLong = false;
                            }

                            if (isRest)
                            {
                                restSuccess2++;
                                restTotal2++;
                                isRest = false;
                            }
                        }
                        
                    }
                }

                if (currentPointsGained == totalPointsInGame)
                {
                    GameTextArea = "Total points gained";
                }
            }

        }
        void SevenPoint()
        {
            if (currentAmountRedPotted <= 15 && currentPointsGained < 140)
            {
                if(!red)
                {
                    if (player1Turn)
                    {
                        potsSuccessPlayer1++;
                        totalTriesPlayer1++;
                        currentPointsGained += 7;
                        Player1Score = 7;
                        Player1Break = 7;                       
                        GameTextArea = "Player 1 scored 7 points\n";                        
                        red = true;

                        if (isLong)
                        {
                            longSuccess1++;
                            longTotal1++;
                            isLong = false;
                        }

                        if (isRest)
                        {
                            restSuccess1++;
                            restTotal1++;
                            isRest = false;
                        }
                    }
                    else
                    {
                        potsSuccessPlayer2++;
                        totalTriesPlayer2++;
                        currentPointsGained += 7;
                        Player2Score = 7;
                        Player2Break = 7;                        
                        GameTextArea = "Player 2 scored 7 points\n";                        
                        red = true;

                        if (isLong)
                        {
                            longSuccess2++;
                            longTotal2++;
                            isLong = false;
                        }

                        if (isRest)
                        {
                            restSuccess2++;
                            restTotal2++;
                            isRest = false;
                        }
                    }
                }
               
            }
            else
            {
                if (currentAmountRedPotted == 15 && currentPointsGained == 140)
                {
                    if (!black)
                    {
                        if(player1Turn)
                        {
                            Player1Score = 7;
                            Player1Break = 7;
                            currentPointsGained += 7;
                            black = true;

                            if (isLong)
                            {
                                longSuccess1++;
                                longTotal1++;
                                isLong = false;
                            }

                            if (isRest)
                            {
                                restSuccess1++;
                                restTotal1++;
                                isRest = false;
                            }
                        } else
                        {
                            Player2Score = 7;
                            Player2Break = 7;
                            currentPointsGained += 7;
                            black = true;

                            if (isLong)
                            {
                                longSuccess2++;
                                longTotal2++;
                                isLong = false;
                            }

                            if (isRest)
                            {
                                restSuccess2++;
                                restTotal2++;
                                isRest = false;
                            }
                        }                       
                    }
                }

                if (currentPointsGained == totalPointsInGame)
                {
                    GameTextArea = "Total points gained";
                }
            }

        }
        void PotMissed()
        {
            if(player1Turn)
            {
                player1Turn = false;
                player1Break = 0;
                Player1Break = 0;
                totalTriesPlayer1++;
                if (isLong)
                {
                    longTotal1++;
                    isLong = false;
                }

                if (isRest)
                {
                    restTotal1++;
                    isRest = false;
                }
                GameTextArea = "Player 1 missed\n";
            } else
            {
                player1Turn = true;
                player2Break = 0;
                Player2Break = 0;
                totalTriesPlayer2++;
                if (isLong)
                {
                    longTotal2++;
                    isLong = false;
                }

                if (isRest)
                {
                    restTotal2++;
                    isRest = false;
                }
                GameTextArea = "Player 2 missed\n";
            }            
        }
        void RestEnabled()
        {
            isRest = true;
        }
        void LongEnabled()
        {
            isLong = true;
        }
        private void CheckStats(object sender)
        {
            _navigation.PushAsync(new StatisticPage(potsSuccessPlayer1, totalTriesPlayer1,
                potsSuccessPlayer2, totalTriesPlayer2,
                longSuccess1, longTotal1,
                longSuccess2, longTotal2,
                restSuccess1, restTotal1,
                restSuccess2, restTotal2,
                player1Turn));
        }
    }
}
