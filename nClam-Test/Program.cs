using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;
using nClam;
using Nito.AsyncEx;
namespace nClam_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            AsyncContext.Run(() => MainAsync(args));
        }
        static async void MainAsync(string[] args)
        {
            Console.WriteLine("Scanning Test Document...");
            await ScanFile(@"TestFiles/TestDocument.docx");

            Console.WriteLine("Scanning Test Photo...");
            await ScanFile(@"TestFiles/TestPhoto.jpeg");

            Console.WriteLine("Scanning Test Video...");
            await ScanFile(@"TestFiles/TestVideo.mov");

            Console.WriteLine("Scanning Test Virus...");
            await ScanFile(@"TestFiles/TestVirus.txt");

            Console.ReadKey();
        }

        private static async Task<bool> ScanFile(string file)
        {
            ClamClient clam = new ClamClient("localhost", 3310);
            
            ClamScanResult scanResult = await clam.SendAndScanFileAsync(file);

            switch (scanResult.Result)
            {
                case ClamScanResults.Clean:
                    Console.WriteLine("The file is clean!");
                    break;
                case ClamScanResults.VirusDetected:
                    Console.WriteLine("Virus Found!");
                    Console.WriteLine("Virus name: {0}", scanResult.InfectedFiles.First().VirusName);
                    break;
                case ClamScanResults.Error:
                    Console.WriteLine("An error occured! Error: {0}", scanResult.RawResult);
                    break;
            }
            return true;
        }
    }
}
