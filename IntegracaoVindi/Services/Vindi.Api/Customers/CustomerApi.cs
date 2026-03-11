using IntegracaoVindi.Services.Builders;
using IntegracaoVindi.Services.Filters;
using IntegracaoVindi.Services.Models;
using IntegracaoVindi.Services.Vindi.Api.Helpers;
using IntegracaoVindi.Vindi.Api;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace IntegracaoVindi.Services.Vindi.Api.Customers
{
    public sealed class CustomerApi : VindiApi
    {
        #region Propriedades

        private readonly string _endpoint;

        #endregion


        #region Constructors

        public CustomerApi(string token) : base(token)
        {
            _endpoint = EndpointHelpers.Routes(Enumerados.ERoutesApi.Customers);
        }

        #endregion

        private async Task<Response<T>> Pesquisar<T>(string query)
        {
            var request = _endpoint + query;

            using var client = ObterClient();
            using var response = await client.GetAsync(request);

            var _response = new Response<T>();

            try
            {
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                _response.Data = JsonConvert.DeserializeObject<T>(content);
                _response.Success = true;
            }
            catch (Exception)
            {
                _response.Success = false;
                _response.Error = $"{response.StatusCode} - {response.ReasonPhrase}";
            }

            return _response;
        }



        public async Task<Response<Models.Customers>> Listar(params QueryFilter[] filters)
        {
            var request = _endpoint + QueryBuilder.Build(filters);
            return await Pesquisar<Models.Customers>(request);

        }

        public async Task<Response<Models.Customer>> PesquisarPorId(string id)
        {
            var request = $"/{id}";

            return await Pesquisar<Models.Customer>(request);
        }

    }
}
