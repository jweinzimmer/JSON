using Newtonsoft.Json;
using ProviderJSONConverter.Core.Errors;
using ProviderJSONConverter.Data.Components;
using System;
using System.Collections.Generic;
using System.IO;

namespace ProviderJSONConverter.Data.IO
{
    public class JSONFileReader
    {
        private string readPath;

        public JSONFileReader(string readPath)
        {
            this.readPath = readPath;
        }

        public List<ProviderPlan> ReadPlans()
        {
            var providerPlanList = new List<ProviderPlan>();
            try
            {
                var planList = JsonConvert.DeserializeObject<List<JSONPlan>>(File.ReadAllText(this.readPath + @"\plans.json"));

                foreach (var plan in planList)
                {
                    foreach (var tier in plan.network)
                    {
                        providerPlanList.Add(new ProviderPlan
                            {
                                plan_id_type = plan.plan_id_type,
                                plan_id = plan.plan_id,
                                network_tier = tier.network_tier
                            });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ExceptionBuilder.BuildException(ex));
                throw;
            }
            return providerPlanList;
        }

    }
}
