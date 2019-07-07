using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Example11
{
    public static class Program
    {
        public static void Main()
        {
            string result = DownloadContent().Result;
            Console.WriteLine(result);

            Console.ReadLine();
        }
        public static async Task<string> DownloadContent()
        {
            using (HttpClient client = new HttpClient())
            {
                string result = await client.GetStringAsync("http://kudchikarsk.com");
                return result;
            }
        }
    }
}
