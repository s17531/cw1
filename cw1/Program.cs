using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace cw1
{
    class Program
    {
        public static async Task Main(string[] args)
        {

            // Console.WriteLine("Hello World!");

            // var newPerson = new Person { FirstName = "Daniel" };

            var url = args.Length > 0 ? args[0] : "https://www.pja.edu.pl";
            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync(url); //pobranie asynchroniczne

            if(response.IsSuccessStatusCode) //2xx -komunikaty od serwera
            {
                string htmlContent = await response.Content.ReadAsStringAsync();
                var regex = new Regex("[a-z]+[a-z0-9]*@[a-z0-9]+\\.[a-z]+\\.[a-z]*", RegexOptions.IgnoreCase);
                //email regex

                var matches = regex.Matches(htmlContent);

                foreach (var match in matches)
                {
                    Console.WriteLine(match.ToString());
                }

            }
         }
    }
}
