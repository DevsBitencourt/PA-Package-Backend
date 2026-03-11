using Newtonsoft.Json;
using System.Collections.Generic;

namespace IntegracaoVindi.Services.Vindi.Api.Customers.Models
{
    public class Customers
    {
        [JsonProperty(PropertyName = "customers")]
        public IList<Customer>? CustomersList { get; set; }
    }
}
