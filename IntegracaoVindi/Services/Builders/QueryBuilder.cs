using IntegracaoVindi.Services.Enumerados;
using IntegracaoVindi.Services.Filters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IntegracaoVindi.Services.Builders
{
    internal class QueryBuilder
    {

        private static Dictionary<CondicionalOperator, List<string>> CreateCondicionals()
        {
            return new Dictionary<CondicionalOperator, List<string>>()
            {
                { CondicionalOperator.And, new List<string>() },
                { CondicionalOperator.Or, new List<string>() }
            };
        }

        private static string GetQuery(Dictionary<CondicionalOperator, List<string>> conditions)
        {
            var conditionsAnd = string.Join(" AND ", conditions[CondicionalOperator.And]);
            var conditionsOr = string.Join(" OR ", conditions[CondicionalOperator.Or]);

            if (conditions[CondicionalOperator.And].Count > 0 && conditions[CondicionalOperator.Or].Count == 0)
            {
                return conditionsAnd;
            }

            if (conditions[CondicionalOperator.And].Count == 0 && conditions[CondicionalOperator.Or].Count > 0)
            {
                return conditionsOr;
            }

            return $"({conditionsAnd})OR({conditionsOr})";

        }

        public static string Build(IEnumerable<QueryFilter> filters)
        {
            if (filters == null || !filters.Any())
                return string.Empty;

            var conditions = CreateCondicionals();

            foreach (var filter in filters)
            {
                var _filter = BuildFilter(filter);

                conditions[filter.Condicional].Add(_filter);
            }

            var query = GetQuery(conditions);

            if (string.IsNullOrEmpty(query)) return string.Empty;

            return $"?query={Uri.EscapeDataString(query)}";
        }

        private static string BuildFilter(QueryFilter filter)
        {
            var value = FormatValue(filter);

            return filter.Operator switch
            {
                FilterOperator.Contem => $"{filter.Field}:{value}",
                FilterOperator.Igual => $"{filter.Field}={value}",
                FilterOperator.Maior => $"{filter.Field}>{value}",
                FilterOperator.MaiorOuIgual => $"{filter.Field}>={value}",
                FilterOperator.Menor => $"{filter.Field}<{value}",
                FilterOperator.MenorOuIgual => $"{filter.Field}<={value}",
                FilterOperator.Negacao => $"-{filter.Field}:{value}",
                FilterOperator.None => $"{filter.Field}={value}",
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private static string FormatValue(QueryFilter filter)
        {
            // Campos que não suportam "contains", forçar aspas
            bool mustQuote = filter.Operator == FilterOperator.Igual && filter.Value.Contains(' ');
            bool restrictedField = filter.Operator == FilterOperator.None;

            return mustQuote || restrictedField
                ? $"\"{filter.Value}\""
                : filter.Value;
        }
    }
}
