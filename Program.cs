using System;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace testproj3
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadConfig().GetAwaiter().GetResult();
        }

        static async Task ReadConfig()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://raw.githubusercontent.com/ljharb/json-file-plus/master/package.json");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            JObject obj = JObject.Parse(responseBody);
            Console.WriteLine(obj.GetValue("repository"));
           // Console.ReadLine();
        }
    }
}
