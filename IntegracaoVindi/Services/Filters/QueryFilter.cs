using IntegracaoVindi.Services.Enumerados;

namespace IntegracaoVindi.Services.Filters
{
    public class QueryFilter
    {
        public string Field { get; set; }
        public string Value { get; set; }
        public FilterOperator Operator { get; set; }
        public CondicionalOperator Condicional { get; set; } = CondicionalOperator.And;
    }
}
