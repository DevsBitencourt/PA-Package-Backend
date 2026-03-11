namespace IntegracaoVindi.Services.Models
{
    public class Response<T>
    {
        public bool Success { get; set; }
        public string Error { get; set; }
        public T Data { get; set; }
    }
}
