using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            var url = "http://whattomine.com/coins.json";
            //var currencyRates = _download_serialized_json_data<RootObject>(url);


            var json = download_serialized_json_data2(url); ;
            JObject rss = JObject.Parse(json);

            Dictionary<string, int> coinProfit = new Dictionary<string, int>();

            List<String> coinsList = new List<string>(new string[]
          { "Feathercoin", "Nicehash-NeoScrypt", "Nicehash-Equihash",
              "Altcommunity", "Phoenixcoin", "Zcash", "Zencash", "Hush", "Zclassic", "EthereumClassic",
              "Ethereum", "Pirl", "Nicehash-Lyra2REv2", "Vertcoin", "Nicehash-Ethash", "Monacoin", "GroestlCoin",
              "Musicoin", "Expanse", "Orbitcoin", "Metaverse", "Komodo", "Ubiq", "LBRY", "Nicehash-Skunkhash",
              "Electroneum", "Sibcoin", "Nicehash-X11Gost", "Nicehash-LBRY", "Karbowanec",  "Nicehash-CryptoNight",
              "Decred", "Monero", "Sumokoin", "Nicehash-Blake (14r)", "PascalLite", "Halcyon","Bytecoin","Pascalcoin",
              "Soilcoin", "Nicehash-Pascal", "Sia","Nicehash-Blake (2b)","DGB-Groestl", "Myriad-Groestl",  "DigitalNote"  });


            foreach (var coin in coinsList)
            {
                try
                {
                    int profit = (int)rss["coins"][coin]["profitability"];
                    coinProfit.Add(coin, profit);
                }
                catch(Exception e)
                {

                }
            }

            var sortedCoinsProfitList = MergeSorter.MergeSort(coinProfit);

            foreach (KeyValuePair<string, int> element in sortedCoinsProfitList)
            {
                Console.Write(element.Key);
                Console.Write(" ");
                Console.Write(element.Value);
                Console.WriteLine(" ");
            }

            //   Console.WriteLine(coinProfit["EthereumClassic"]);
            Console.ReadLine();

        }


        private static T _download_serialized_json_data<T>(string url) where T : new()
        {
            using (var w = new WebClient())
            {
                var json_data = string.Empty;
                // attempt to download JSON data as a string
                try
                {
                    json_data = w.DownloadString(url);
                }
                catch (Exception) { }
                // if string with JSON data is not empty, deserialize it to class and return its instance 
                return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
            }
        }

        private static string download_serialized_json_data2(string url)
        {
            using (var w = new WebClient())
            {
                var json_data = string.Empty;
                // attempt to download JSON data as a string
                try
                {
                    json_data = w.DownloadString(url);
                }
                catch (Exception) { }
                // if string with JSON data is not empty, deserialize it to class and return its instance 
                return json_data;
            }
        }

    }
}