using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace APILab.Models
{
    public class CardsDAL
    {
        public CardsModel GetData(string deckID)
        {
            string url = $"https://deckofcardsapi.com/api/deck/{deckID}/draw/?count=5";

            HttpWebRequest request = WebRequest.CreateHttp(url);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream());

            string JSON = reader.ReadToEnd();

            CardsModel result = JsonConvert.DeserializeObject<CardsModel>(JSON);

            return result;
        }

        public CardsModel ShuffleDeck(string deckID)
        {
            string url = $"https://deckofcardsapi.com/api/deck/{deckID}/shuffle/";

            HttpWebRequest request = WebRequest.CreateHttp(url);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream());

            string JSON = reader.ReadToEnd();

            CardsModel result = JsonConvert.DeserializeObject<CardsModel>(JSON);

            return result;
        }

        public CardsModel AddToPile(string deckID, string value)
        {
            string url = $"https://deckofcardsapi.com/api/deck/{deckID}/pile/Keepers/add/?cards={value}";

            HttpWebRequest request = WebRequest.CreateHttp(url);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream());

            string JSON = reader.ReadToEnd();

            CardsModel result = JsonConvert.DeserializeObject<CardsModel>(JSON);

            return result;
        }
    }
}
