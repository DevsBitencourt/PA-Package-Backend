using IntegracaoVindi.Services.Enumerados;
using IntegracaoVindi.Services.Enumerados.Customers;
using System;

namespace IntegracaoVindi.Services.Filters
{
    public sealed class CustomerFilter : FilterBase
    {

        #region Metodos publicos

        public CustomerFilter Id(FilterOperator filterOperator, string code, CondicionalOperator condicional = CondicionalOperator.And)
        {
            Filters.Add(new QueryFilter()
            {
                Field = "id",
                Operator = filterOperator,
                Value = code,
                Condicional = condicional
            });
            return this;
        }

        public CustomerFilter Name(FilterOperator filterOperator, string code, CondicionalOperator condicional = CondicionalOperator.And)
        {
            Filters.Add(new QueryFilter()
            {
                Field = "name",
                Operator = filterOperator,
                Value = $"'{code}'",
                Condicional = condicional
            });
            return this;
        }

        public CustomerFilter Status(FilterOperator filterOperator, ECustomerStatus status, CondicionalOperator condicional = CondicionalOperator.And)
        {
            Filters.Add(new QueryFilter()
            {
                Field = "status",
                Operator = filterOperator,
                Value = status == ECustomerStatus.Active ? "active" : "inactive",
                Condicional = condicional
            });
            return this;
        }

        public CustomerFilter Code(string code, CondicionalOperator condicional = CondicionalOperator.And)
        {
            Filters.Add(new QueryFilter()
            {
                Field = "code",
                Operator = FilterOperator.None,
                Value = code,
                Condicional = condicional
            });
            return this;
        }

        public CustomerFilter Email(string code, CondicionalOperator condicional = CondicionalOperator.And)
        {
            Filters.Add(new QueryFilter()
            {
                Field = "email",
                Operator = FilterOperator.None,
                Value = code,
                Condicional = condicional
            });
            return this;
        }

        public CustomerFilter RegistryCode(string code, CondicionalOperator condicional = CondicionalOperator.And)
        {
            Filters.Add(new QueryFilter()
            {
                Field = "registry_code",
                Operator = FilterOperator.None,
                Value = code,
                Condicional = condicional
            });
            return this;
        }

        public CustomerFilter CreatedAt(FilterOperator filterOperator, DateTime date, CondicionalOperator condicional = CondicionalOperator.And)
        {
            Filters.Add(new QueryFilter()
            {
                Field = "created_at",
                Operator = filterOperator,
                Value = date.ToString("yyyy-MM-dd"),
                Condicional = condicional
            });
            return this;
        }

        public CustomerFilter UpdatedAt(FilterOperator filterOperator, DateTime date, CondicionalOperator condicional = CondicionalOperator.And)
        {
            Filters.Add(new QueryFilter()
            {
                Field = "updated_at",
                Operator = filterOperator,
                Value = date.ToString("yyyy-MM-dd"),
                Condicional = condicional
            });
            return this;
        }

        #endregion
    }
}
