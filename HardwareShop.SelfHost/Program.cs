using HardwareShop.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;


namespace HardwareShop.SelfHost
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ServiceHost host = new ServiceHost(typeof(HSService));
                host.Open();
                Console.WriteLine("Nacisnij zeby zakonczyc");
                Console.ReadKey();
            }

            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }



        }
    }
}