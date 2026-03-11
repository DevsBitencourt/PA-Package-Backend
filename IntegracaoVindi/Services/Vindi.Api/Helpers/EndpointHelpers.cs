using IntegracaoVindi.Services.Vindi.Api.Enumerados;
using System.Collections.Generic;
using System.Text;

namespace IntegracaoVindi.Services.Vindi.Api.Helpers
{
    internal static class EndpointHelpers
    {

        private static IDictionary<ERoutesApi, string> ListRoutes()
        {
            return new Dictionary<ERoutesApi, string> {

                { ERoutesApi.Customers, "api/v1/customers" }

            };
        }

        internal static string Routes(ERoutesApi eRoutes)
        {
            return ListRoutes()[eRoutes];
        }

        internal static string GetUtf8(string value)
        {
            var bit = Encoding.UTF8.GetBytes(value);
            return Encoding.UTF8.GetString(bit);
        }

    }
}
