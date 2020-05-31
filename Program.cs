using System;
using System.IO;
using System.Threading.Tasks;
using nClam;

namespace ClamPing
{
    class Program
    {
        const string SERVER_URL = "localhost";
        const int SERVER_PORT = 3310;
        const string fileName = "test.mp4";
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            ClamClient client = new ClamClient(SERVER_URL, SERVER_PORT);
            bool ping = Task.Run(() => client.PingAsync()).Result;

            Console.WriteLine($"Ping Successful? {ping}");

            ClamScanResult result = Task.Run(() => client.ScanFileOnServerAsync(Path.Combine(Environment.CurrentDirectory, fileName))).Result;
            
            Console.WriteLine($"Scan Successful? {result.RawResult}");

        }
    }
}
