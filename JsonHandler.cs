using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BMS_Tickets
{
    internal class JsonHandler
    {
        private bool Success { get;  set; }
        private JObject Result { get;  set; }

        private JToken TicketResult { get; set; }

        public void SplitInput(HttpResponseMessage input)
        {
            String response =  input.Content.ReadAsStringAsync().Result;
            var responseData = (JObject)(JsonConvert.DeserializeObject(response));

            Success = (bool)(responseData.Property("success").Value);

            Result = (JObject)(responseData.Property("result").Value);
        }

        public void SplitForTickets(HttpResponseMessage input)
        {
            String response = input.Content.ReadAsStringAsync().Result;
            var responseData = (JObject)(JsonConvert.DeserializeObject(response));

            Success = (bool)(responseData.Property("success").Value);

            TicketResult = responseData.Property("result").Value;
        }
    

        public bool GetSuccess()
        {
            return Success;
        }

        public string GetAccessToken()
        {
            var accessToken = (string)(Result.Property("accessToken").Value);

            return accessToken;
        }

        public string GetRefreshToken()
        {
            var refreshToken = (string)(Result.Property("refreshToken").Value);

            return refreshToken;
        }

        public DateTime GetAccessExpireOn()
        {
            var accessExpire = (DateTime)(Result.Property("accessTokenExpireOn").Value);

            return accessExpire;
        }

        public DateTime GetRefreshExpireOn()
        {
            var refreshExpire = (DateTime)(Result.Property("refreshTokenExpireOn").Value);

            return refreshExpire;
        }

        public int GetTicketCount()
        {
            var ticketCount = (int)(Result.Property("count").Value);

            return ticketCount;
        }

        public JToken GetTicketPage()
        {
            return TicketResult;
        }

    }
}
