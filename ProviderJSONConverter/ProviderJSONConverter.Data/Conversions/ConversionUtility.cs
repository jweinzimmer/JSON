using ProviderJSONConverter.Core.Errors;
using ProviderJSONConverter.Data.Components;
using ProviderJSONConverter.Data.IO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;

namespace ProviderJSONConverter.Data.Conversions
{
    public static class ConversionUtility
    {
        private static List<ProviderPlan> planList;

        public static List<Provider> Flatten(List<Provider> list)
        {
            var flatList = new List<Provider>();
            var tempList = new List<Provider>();

            try
            {
                planList = new JSONFileReader(ConfigurationManager.AppSettings["JSONPlans_FL"]).ReadPlans();

                // we're gonna start with the fully padded out plans, then flatten by address.
                list = PadOutWithPlans(list);

                foreach (var provider in list)
                {

                    if (!flatList.Contains(provider))
                    {
                        tempList = Provider.findProviders(list, provider);

                        foreach (var item in tempList)
                        {
                            if (!flatList.Contains(item))
                            {
                                flatList.Add(item);
                            }
                            
                            Provider uniqueProvider = Provider.findProvider(flatList, item);
                           
                            if (!uniqueProvider.addressExists(item.address))
                            {
                                uniqueProvider.addresses.Add(item.address);
                            }
                        }
                    }
                }
                
                return flatList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ExceptionBuilder.BuildException(ex));
                throw;
            }
        }

        private static List<ProviderPlan> MapFLPlansFromNetwork(string network)
        {
            var plans = new List<ProviderPlan>();
            if (network.Equals("PPO"))
            {
                //BlueDental Choice plan ids
                plans = planList.Where(x => x.plan_id.Equals("30115FL0020001") || x.plan_id.Equals("30115FL0050001")).ToList();
            }
            else if (network.Equals("CoPay"))
            {
                plans = planList.Where(x => x.plan_id.Equals("30115FL0010001") || x.plan_id.Equals("30115FL0040001")).ToList();
            }
            else
            {
                throw new ArgumentException("Invalid Argument to " + MethodBase.GetCurrentMethod().Name +  ": Network tier not recognized.");
            }

            return plans;
        }

        private static List<Provider> PadOutWithPlans(List<Provider> providerList)
        {
            try
            {
                foreach (var provider in providerList)
                {
                    var networks = provider.networks.Split(',')
                        .Where(x => x.Equals("PPO") || x.Equals("CoPay")).ToList();

                    provider.plans = new List<ProviderPlan>();

                    foreach (var tier in networks)
                    {
                        provider.plans.AddRange(MapFLPlansFromNetwork(tier));
                    }
                }

                return providerList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ExceptionBuilder.BuildException(ex));
                throw;
            }
        }
    }
}
