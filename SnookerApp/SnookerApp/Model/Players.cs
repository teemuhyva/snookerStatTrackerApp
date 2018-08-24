using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SnookerApp
{
    public class Players {

        public string PlayerName { get; set; }
        public string Player1 { get; set; }
        public string Player2 { get; set; }

        public static ObservableCollection<Players> PlayerList = new ObservableCollection<Players>
        {
            new Players { PlayerName = "Teemu" },
            new Players { PlayerName = "Tomi" },
            new Players { PlayerName = "Tuomas" }
        };
        
    }
}
