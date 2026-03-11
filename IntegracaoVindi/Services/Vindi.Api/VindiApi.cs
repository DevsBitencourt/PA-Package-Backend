using System;
using System.Net.Http;
using System.Text;

namespace IntegracaoVindi.Vindi.Api
{
    public abstract class VindiApi
    {

        #region Propriedades

        private readonly string _token;
        private readonly string _url = "https://app.vindi.com.br:443";

        #endregion

        #region Construtor

        public VindiApi(string token)
        {
            _token = token;
        }

        #endregion

        #region Methods protecteds

        protected virtual HttpClient ObterClient()
        {
            var client = new HttpClient()
            {
                BaseAddress = new Uri(_url)
            };

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", GetToken());
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        #endregion

        #region Methods privates

        private string GetToken()
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_token}:"));
        }

        #endregion
    }
}
