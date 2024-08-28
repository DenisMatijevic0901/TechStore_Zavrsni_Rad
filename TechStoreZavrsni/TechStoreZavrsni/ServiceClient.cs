using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TechStoreZavrsni
{
    internal class ServiceClient
    {
        public static CrmServiceClient getCRMService()
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                string connectionString = ConfigurationManager.ConnectionStrings["CRMConnectionString"].ConnectionString; // dohvaca se iz config-a
                CrmServiceClient serviceClient = new CrmServiceClient(connectionString);

                if (serviceClient.IsReady == true)
                {
                    return serviceClient;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }

        public static Guid uom = new Guid("9c36b8d4-718c-4a11-920a-fa8a177b3f80");
        public static Guid priceList = new Guid("65029c08-f01f-eb11-a812-000d3a33e825");
        public static Guid uomSchedule = new Guid("db949f60-6edb-4cfb-adf7-050c60769746");
        public static Guid productUnit = new Guid("ae39f330-41c1-4543-aab1-05002b02c09b");
        public static Guid revenue = new Guid("9241f883-ceb1-4600-9c32-7cb1d9ecf6a3");
    }
}
