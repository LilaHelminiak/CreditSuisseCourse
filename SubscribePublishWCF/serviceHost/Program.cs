using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;


namespace Microsoft.ServiceModel.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(SampleService)))
            {
                host.Open();

                Console.WriteLine("The service is ready at: {0}", host.BaseAddresses.FirstOrDefault().ToString());
                Console.WriteLine("Press <Enter> to stop the service");
                Console.ReadKey();
                host.Close();
            }
        }
    }
}
