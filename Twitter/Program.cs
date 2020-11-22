using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Net;
using TweetSharp;

namespace Twitter
{
    class Program
    {
        private static string customerKey = "TjsEQnquw3rpEALMeVm9a7k";
        private static string customerSecret = "dooiojrHyPhhr9EeB2M7fjOvGF2ytyC3GloVlzvAlOIp";
        private static string token = "154584825-3m9ylodyKRmbiBMaiK7ozqxcrOoA0sP78d";
        private static string tokenSecret = "ZU7BmvyxQsQx7YkY0bgq8vDyuzZnckNu7ruKM6ub1Y";
        private static string bearer_token = "AAAAAAAAAAAAAAAAAAAE3jJwEAAAAAddAiUs%2FLIbb3cKmIIrooXhLMPVRr960Hn9eWALkrAmY1zVBYzpOTHk7Niue6iJ";


        private static TwitterService service = new TwitterService(customerKey, customerSecret,token, tokenSecret);
        static void Main(string[] args)
        {
            Console.WriteLine($"<{DateTime.Now}> - Bot Started");
            SendTweet("Hello World!");
            Console.Read();
        }


        private static void SendTweet(string _status)
        {
            service.SendTweet(new SendTweetOptions { Status = _status }, (tweet, response) =>
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"<{DateTime.Now}> - Tweet Sent");
                    Console.ResetColor();

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"<Error> " + response.Error.Message);
                    Console.ResetColor();
                }
            });
        }
    }
}
