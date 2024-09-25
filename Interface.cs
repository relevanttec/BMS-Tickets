using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BMS_Tickets
{
    static class Interface
    {
        private static String AccessToken { get; set; }
        private static String RefreshToken { get; set; }

        public static DateTime AccessTokenExpire { get; set; }

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

                HttpResponseMessage response = await MyClient.SendAsync(request);

            
                string ResponseContent = await response.Content.ReadAsStringAsync();

                //Deserialize the JSON response text for consumption
                var data = (JObject)(JsonConvert.DeserializeObject(ResponseContent));

                //Obtain the value of "success"
                bool Success = (bool)(data.Property("success").Value);

                //Succesful auth API call if true
                if (Success == true)
                {
                    //Store the Call results
                    var Result = (JObject)(data.Property("result").Value);

                    //Extract the AccessToken 
                    AccessToken = (String)(Result.Property("accessToken").Value);

                    RefreshToken = (String)(Result.Property("refrehToken").Value);

                    AccessTokenExpire = (DateTime)(Result.Property("accessTokenExpireOn"))


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
        public static async void GetPageCount(String start, String end)
        {
            //Clear any lingering headers, assign the accept and auth headers
            MyClient.DefaultRequestHeaders.Clear();
            MyClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            MyClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);


            //Build our parameter string in the format "?NAME=VALUE&NAME=VALUE&...."
            String Parameters = "?OpenDateFrom=" + start + "&OpenDateTo=" + end + "&ExcludeCompleted=1";

            try
            {
                //Build request,GET method, parameter string attached on the end
                var request = new HttpRequestMessage(HttpMethod.Get, "servicedesk/tickets/count" + Parameters);

                HttpResponseMessage response = await MyClient.SendAsync(request);

                string ResponseContent = await response.Content.ReadAsStringAsync();

                var data = (JObject)(JsonConvert.DeserializeObject(ResponseContent));

                var success = (bool)(data.Property("success").Value);

                if (success)
                {

                    var result = (JObject)data.Property("result").Value;

                    var TicketCount = (double)(result.Property("count").Value);

                    PageCount = (int)(Math.Ceiling(TicketCount / 100));

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

        public static async void GetTickets(String start, String end, String path)
        {
            const String PageSize ="100";

            //Clear any lingering headers, assign the accept and auth headers
            MyClient.DefaultRequestHeaders.Clear();
            MyClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            MyClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);

            // String of parameters for the API call
            String Parameters = "?Filter.OpenDateFrom=" + start + "&Filter.OpenDateTo=" + end + "&Filter.ExcludeCompleted=true" +
                "&PageSize=" + PageSize + "&PageNumber=";

            // Initialize a list to hold all objects obtained from the paged API calls
            List<JToken> AllTickets = new List<JToken>();

            // Call the searchselect endpoint PageCount number of times
            for (int currPage = 1; currPage <= PageCount; currPage++)
            {
                // Create the request, notice the appended page number for paged calls
                var request = new HttpRequestMessage(HttpMethod.Get, "servicedesk/tickets/searchselect" + Parameters + currPage);

                HttpResponseMessage response = await MyClient.SendAsync(request);

                // Convert the response content to a string
                string ResponseContent = await response.Content.ReadAsStringAsync();

                // Deserialize and convert to a JObject the response content
                var data = (JObject)(JsonConvert.DeserializeObject(ResponseContent));

                // Obtain the success value to determine if call was made successfully
                var success = (bool)(data.Property("success").Value);

                if (success)
                {
                    // The result property holds the ticket information (100 per page)
                    var result = data.Property("result").Value;

                    // Append the tickets to the initialized AllTokens list
                    AllTickets.Add(result);
                }
                else
                {
                    MessageBox.Show("Something went wrong retrieving your tickets");
                }


            }

            // Serialized the list of tickets for writing to a file
            var SerializedTickets = JsonConvert.SerializeObject(AllTickets);

            // Write the serialized JSON object to the file selected by the user
            System.IO.File.WriteAllText(@path + @"\Tickets.json", SerializedTickets);

        }

        public static async void GetRefresh()
        {
            //Clear any existing headers and add the accept header
            MyClient.DefaultRequestHeaders.Clear();
            MyClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var requestData = new List<KeyValuePair<String, String>>();
            requestData.Add(new KeyValuePair<String, String>("AccessToken", AccessToken));
            requestData.Add(new KeyValuePair<String, String>("RefreshToken", RefreshToken));

            var content = new FormUrlEncodedContent(requestData);

            try
            {

                //Define the request then make the call
                var request = new HttpRequestMessage(HttpMethod.Post, "security/refreshtoken") { Content = content };

                HttpResponseMessage response = await MyClient.SendAsync(request);


                string ResponseContent = await response.Content.ReadAsStringAsync();

                //Deserialize the JSON response text for consumption
                var data = (JObject)(JsonConvert.DeserializeObject(ResponseContent));

                //Obtain the value of "success"
                bool Success = (bool)(data.Property("success").Value);

                //Succesful auth API call if true
                if (Success == true)
        }

    }
}





