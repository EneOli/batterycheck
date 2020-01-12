using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BatteryCheck
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            PowerStatus powerStatus = SystemInformation.PowerStatus;
            float batteryLifePercent = powerStatus.BatteryLifePercent * 100;
            while (true)
            {
                batteryLifePercent = powerStatus.BatteryLifePercent * 100;
                Console.WriteLine("Battery life: " + batteryLifePercent + "%");

                if (batteryLifePercent <= 20)
                {
                    try
                    {
                        await client.GetAsync("http://192.168.1.100");
                        //payload
                        //var content = new StringContent("greetings from c#", Encoding.UTF8, "application/json");
                        //await client.PostAsync("http://192.168.1.100", content);
                    } catch (Exception e)
                    {
                        Console.WriteLine("Error: " + e.Message);
                    }
                }

                System.Threading.Thread.Sleep(5000); // thread sync
            }

        }
    }
}
