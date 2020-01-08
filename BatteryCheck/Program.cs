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
        static async void Main(string[] args)
        {
            PowerStatus powerStatus = SystemInformation.PowerStatus;
            float batteryLifePercent = powerStatus.BatteryLifePercent * 100;
            while (true)
            {
                Console.WriteLine("Battery life: " + batteryLifePercent + "%");

                if (batteryLifePercent <= 20)
                {
                    await client.GetAsync("192.168.1.100");
                    //payload
                    //var content = new StringContent("", Encoding.UTF8, "application/json");
                    //await client.PostAsync("greetings from c#", content);
                }

                System.Threading.Thread.Sleep(5000); // thread sync
            }

        }
    }
}
