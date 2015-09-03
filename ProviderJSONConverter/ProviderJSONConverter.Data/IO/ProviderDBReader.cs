using ProviderJSONConverter.Data.Components;
using ProviderJSONConverter.Core.Errors;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace ProviderJSONConverter.Data.IO
{
    public class ProviderDBReader
    {
        public static List<Provider> GetFLProviders()
        {
            var providerList = new List<Provider>();
            try
            {
                using (var sql = new SqlConnection(ConfigurationManager.ConnectionStrings["DentemaxDB"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand(
                        @"SELECT dp.Npi
	                    ,dp.FirstName
	                    ,dp.LastName
                        ,dp.MiddleName
                        ,dp.Suffix
	                    ,addr.Line1
	                    ,addr.Line2
	                    ,addr.city
	                    ,addr.state
	                    ,addr.zip
                        ,dp.PhoneNumber
                        ,dp.ProviderSpecialty
                        ,dp.Network
	                    ,dpn.NetworkType
                        ,dpn.newPatients
                        ,dpn.ImportType
                    FROM DentalProvider dp
                    inner join Network dpn on dpn.ID = dp.ID
                    inner join Address addr on dp.addressid = addr.AddressId
                    WHERE NetworkType IN (0,4)
                    ORDER BY npi", sql);

                    sql.Open();

                    var reader = cmd.ExecuteReader();
                    providerList = SetProvidersFromReader(reader);
                    reader.Close();
                }
                return providerList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ExceptionBuilder.BuildException(ex));
                throw;
            }
        }

        private static List<Provider> SetProvidersFromReader(SqlDataReader reader)
        {
            var providerList = new List<Provider>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    providerList.Add(new Provider
                    {
                        npi = reader["NPI"].ToString(),
                        name = new ProviderName
                        {
                            first = reader["FIRSTNAME"].ToString(),
                            middle = reader["MIDDLENAME"].ToString(),
                            last = reader["LASTNAME"].ToString(),
                            suffix = String.IsNullOrEmpty(reader["SUFFIX"].ToString())
                                ? null : reader["Suffix"].ToString()
                        },
                        address = new Address
                        {
                            address = reader["LINE1"].ToString(),
                            address_2 = reader["LINE2"].ToString(),
                            city = reader["CITY"].ToString(),
                            state = reader["STATE"].ToString(),
                            zip = reader["ZIP"].ToString()
                        },
                        specialty = new List<string>
                            {
                                EnumUtility.Convert(
                                    (DentalProviderSpecialty)Enum.Parse(typeof(DentalProviderSpecialty),
                                    reader["PROVIDERSPECIALTY"].ToString()))
                            },
                        phone = reader["PHONENUMBER"].ToString(),
                        networks = reader["NETWORK"].ToString(),
                        network_type = reader["NETWORKTYPE"].ToString(),
                        import_type = reader["IMPORTTYPE"].ToString(),
                        accepting = Boolean.Parse(reader["NEWPATIENTS"].ToString()),
                        last_updated_on = DateTime.Today.ToString("yyyy-MM-dd")
                    });
                }
            }
            return providerList;
        }

        public static List<Provider> GetHIProviders()
        {
            return new List<Provider>();
        }
    }
}
