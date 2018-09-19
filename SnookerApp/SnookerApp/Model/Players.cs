using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SnookerApp
{
    public class Players {

        HttpClient client = new HttpClient();

        public string PlayerName { get; set; }
        public string Player1 { get; set; }
        public string Player2 { get; set; }

        public string NickName { get; set; }

        public static ObservableCollection<Players> PlayerList = new ObservableCollection<Players>
        {
            new Players { PlayerName = "Teemu" },
            new Players { PlayerName = "Tomi" },
            new Players { PlayerName = "Tuomas" }
        };

        public async Task FindPlayerByNick(string nickName) {
            try {
                string url = "http://localhost:49873/api/findFriendByNick";
                var obj = new Players { NickName = nickName };
                var json = JsonConvert.SerializeObject(obj);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage rm = await client.PostAsync(url, content);

                if (rm.IsSuccessStatusCode) {
                    Debug.WriteLine("Success");
                }
            } catch(Exception e) {
                Debug.WriteLine("Something went wrong " + e.StackTrace);
            }
        }


    }
}
