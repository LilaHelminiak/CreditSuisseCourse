using System;
using System.ServiceModel;

namespace SelfHost
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var host = new ServiceHost(typeof (DataGeneratorServiceLibrary.DataGeneratorService)))
            {
                host.Open();
                Console.WriteLine("The service is ready, press <Enter> to stop the service");
                Console.ReadKey();
                host.Close();
            }
        }
    }
}
