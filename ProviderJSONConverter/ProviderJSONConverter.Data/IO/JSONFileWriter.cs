using Newtonsoft.Json;
using ProviderJSONConverter.Core.Errors;
using ProviderJSONConverter.Data.Components;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProviderJSONConverter.Data.IO
{
    public class JSONFileWriter
    {
        private string writePath;

        public JSONFileWriter(string writePath)
        {
            this.writePath = writePath;
        }

        public bool WriteProviderFile(List<Provider> providerList)
        {
            bool success = false;

            string jsonString = ConvertToJson(providerList);
            try
            {
                var fi = new FileInfo(writePath + @"\providers.json");

                using (var stream = fi.Exists ? fi.Open(FileMode.Truncate) : fi.Create())
                {
                    using (var sw = new StreamWriter(stream))
                    {
                        sw.Write(jsonString.ToString());
                    }
                }
                success = true;
                return success;
            }
            catch (Exception ex)
            {
                //eventually to be replaced with a logging system
                Console.WriteLine(ExceptionBuilder.BuildException(ex));
                throw;
            }
        }

        public string ConvertToJson(List<Provider> providerList)
        {
            StringBuilder str = new StringBuilder();

            str.Append(JsonConvert.SerializeObject(
                    providerList,
                    Formatting.Indented,
                    new JsonSerializerSettings { 
                        NullValueHandling = NullValueHandling.Ignore,
                        DefaultValueHandling = DefaultValueHandling.Ignore
                    }));

            return str.ToString();
        }
    }
}