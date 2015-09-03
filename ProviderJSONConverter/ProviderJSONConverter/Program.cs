using ProviderJSONConverter.Data.Components;
using ProviderJSONConverter.Data.Conversions;
using ProviderJSONConverter.Data.IO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace ProviderJSONConverter.App
{
    class Program
    {
        static void Main(string[] args)
        {
            //foreach (var arg in args)
            //{
                bool passed = false;
                DateTime start = DateTime.Now;
                List<Provider> providerList = new List<Provider>();
                StringBuilder str = new StringBuilder();

                Console.WriteLine("Starting...");

                try
                {
                    //if (arg.Equals("-f"))
                    //{
                    
                    providerList = ProviderDBReader.GetFLProviders();
                    //}
                    //else if (arg.Equals("-h"))
                    //{
                    //    providerList = ProviderDBReader.GetHIProviders();
                    //}
                    //else
                    //{
                    //    Console.WriteLine("Option passed is not a valid argument.");
                    //    return;
                    //}

                    Console.WriteLine("Flattening data...");
                    providerList = ConversionUtility.Flatten(providerList);

                    Console.WriteLine("Converting to JSON...");
                    Console.WriteLine("Starting file write...");

                    passed = new JSONFileWriter(
                        ConfigurationManager.AppSettings["JSONProviders_FL"])
                        .WriteProviderFile(providerList);
                }
                catch (Exception)
                {
                    passed = false;
                }

                double duration = DateTime.Now.Subtract(start).TotalSeconds;

                Console.WriteLine("Process " + (passed ? "COMPLETED" : "FAILED") + " in "
                    + duration + " seconds.");
                Console.Write("Press any key to continue. ");
                Console.ReadKey();
            //}
        }
    }
}
