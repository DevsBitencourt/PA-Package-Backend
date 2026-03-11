using IntegracaoVindi.Services.Filters;
using IntegracaoVindi.Services.Vindi.Api.Customers;
using NUnit.Framework;
using System;

namespace IntegracaoVindi.Tests.Customers
{
    public class CustomerTests
    {
        public CustomerApi customer { get; set; }


        [SetUp]
        public void Setup()
        {
            customer = new CustomerApi("");
        }

        [Test(Description = "Listagem de clientes")]
        public void CustomersList()
        {
            var filter = new CustomerFilter()
                .Name(Services.Enumerados.FilterOperator.Contem, "Persona XPO", Services.Enumerados.CondicionalOperator.And)
                .CreatedAt(Services.Enumerados.FilterOperator.Maior, new DateTime(2018, 08, 21))
                .RegistryCode("12345678912", Services.Enumerados.CondicionalOperator.Or);

            var response = customer.Listar(filter.ToFields()).Result;

            Assert.That(response.Success, Is.True, response.Error, response.Data);
        }

        [Test(Description = "Cliente por Id")]
        public void CustomerId()
        {
            var response = customer.PesquisarPorId("123456").Result;

            Assert.That(response.Success, Is.True, response.Error, response.Data);
        }
    }
}