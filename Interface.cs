using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BMS_Tickets
{
    class Interface
    {
        private static JsonHandler _jsonHandler = new JsonHandler();
        private static string AccessToken { get; set; }
        private static string RefreshToken { get; set; }

        private static DateTime AccessTokenExpire { get; set; }
        private static DateTime RefreshTokenExpire { get; set; }

        private static int PageCount { get; set; }

        static HttpClient MyClient = new HttpClient
        {
            //Set BaseAddress of HttpClient to be used for all calls
            BaseAddress = new Uri("https://api.bms.kaseya.com/v2/")
        };

        //This function defines the authentication, accepts a FormUrlEncodedContent parameter which includes credential info
        public static async void GetAccess(FormUrlEncodedContent content)
        {
            //Clear any existing headers and add the accept header
            MyClient.DefaultRequestHeaders.Clear();
            MyClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                //Define the request then make the call
                var request = new HttpRequestMessage(HttpMethod.Post, "security/authenticate") { Content = content};

                //Successful auth API call if true
                _jsonHandler.SplitInput(await MyClient.SendAsync(request));

                if (_jsonHandler.GetSuccess())
                {

                    //Extract the AccessToken 
                    AccessToken = _jsonHandler.GetAccessToken();

                    RefreshToken = _jsonHandler.GetRefreshToken();

                    AccessTokenExpire = _jsonHandler.GetAccessExpireOn();

                    RefreshTokenExpire = _jsonHandler.GetRefreshExpireOn();

                    RefreshTimer();


                    MessageBox.Show("You have successfully authenticated");
                }

                else
                {
                    MessageBox.Show("Something went wrong, Please try again.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }        
            
        }

        //This function call returns the total number of tickets
        //Takes two, start and end, dates formatted as strings as parameters
        //Each page will be defined to have 100 tickets in subsequent calls
        public static async void GetPageCount(string start, string end)
        {
            //Clear any lingering headers, assign the accept and auth headers
            MyClient.DefaultRequestHeaders.Clear();
            MyClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            MyClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);


            //Build our parameter string in the format "?NAME=VALUE&NAME=VALUE&...."
            string Parameters = "?OpenDateFrom=" + start + "&OpenDateTo=" + end + "&ExcludeCompleted=1";

            try
            {
                //Build request,GET method, parameter string attached on the end
                var request = new HttpRequestMessage(HttpMethod.Get, "servicedesk/tickets/count" + Parameters);

                _jsonHandler.SplitInput(await MyClient.SendAsync(request));

                if (_jsonHandler.GetSuccess())
                {

                    var ticketCount = _jsonHandler.GetTicketCount();

                    PageCount = (int)Math.Ceiling(ticketCount / 100.0);

                    MessageBox.Show("Dates Selected, Pages Counted");
                }
                else
                {
                    MessageBox.Show("Something went wrong. Ensure you authenticated and try again");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static async void GetTickets(string start, string end, string path)
        {
            const string PageSize ="100";

            //Clear any lingering headers, assign the accept and auth headers
            MyClient.DefaultRequestHeaders.Clear();
            MyClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            MyClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);

            // string of parameters for the API call
            string Parameters = "?Filter.OpenDateFrom=" + start + "&Filter.OpenDateTo=" + end + "&Filter.ExcludeCompleted=true" +
                "&PageSize=" + PageSize + "&PageNumber=";

            // Initialize a list to hold all objects obtained from the paged API calls
            List<JToken> AllTickets = new List<JToken>();

            // Call the searchselect endpoint PageCount number of times
            for (int currPage = 1; currPage <= PageCount; currPage++)
            {
                // Create the request, notice the appended page number for paged calls
                var request = new HttpRequestMessage(HttpMethod.Get, "servicedesk/tickets/searchselect" + Parameters + currPage);

                _jsonHandler.SplitForTickets(await MyClient.SendAsync(request));

                if (_jsonHandler.GetSuccess())
                {
                    // The result property holds the ticket information (100 per page)
                    var ticketPage = _jsonHandler.GetTicketPage();

                    // Append the tickets to the initialized AllTokens list
                    AllTickets.Add(ticketPage);
                }
                else
                {
                    MessageBox.Show("Something went wrong retrieving your tickets");
                }


            }

            // Serialized the list of tickets for writing to a file
            var SerializedTickets = JsonConvert.SerializeObject(AllTickets);

            System.Console.WriteLine("Pulled Tickets" + DateTime.Now);
            // Write the serialized JSON object to the file selected by the user
            System.IO.File.WriteAllText(@path + @"\Tickets.json", SerializedTickets);

        }

        public static async void GetRefresh()
        {
            //Clear any existing headers and add the accept header
            MyClient.DefaultRequestHeaders.Clear();
            MyClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var requestData = new List<KeyValuePair<string, string>>();
            requestData.Add(new KeyValuePair<string, string>("AccessToken", AccessToken));
            requestData.Add(new KeyValuePair<string, string>("RefreshToken", RefreshToken));

            var content = new FormUrlEncodedContent(requestData);

            try
            {

                //Define the request then make the call
                var request = new HttpRequestMessage(HttpMethod.Post, "security/refreshtoken") { Content = content };
                
                _jsonHandler.SplitInput(await MyClient.SendAsync(request));

                if (_jsonHandler.GetSuccess())
                {

                    //Extract the AccessToken 
                    AccessToken = _jsonHandler.GetAccessToken();

                    RefreshToken = _jsonHandler.GetRefreshToken();

                    AccessTokenExpire = _jsonHandler.GetAccessExpireOn();

                    RefreshTokenExpire = _jsonHandler.GetRefreshExpireOn();

                    System.Console.WriteLine("Refreshed Token" + DateTime.Now);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static void RefreshTimer()
        {
            var fourteenMinutes = 15 * 60 * 1000;
            var CallTimer = new System.Timers.Timer(fourteenMinutes);
            CallTimer.Elapsed += (s, en) => GetRefresh();
            CallTimer.AutoReset = true;
            CallTimer.Enabled = true;
        }

    }
}