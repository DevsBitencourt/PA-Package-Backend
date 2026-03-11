using System.Collections.ObjectModel;
using System.Linq;

namespace IntegracaoVindi.Services.Filters
{
    public abstract class FilterBase
    {
        #region Propriedades

        protected Collection<QueryFilter> Filters { get; set; }

        #endregion

        #region Construtores

        public FilterBase()
        {
            Filters = new Collection<QueryFilter>();
        }

        #endregion

        #region Propriedades

        public QueryFilter[] ToFields()
        {
            return Filters.ToArray();
        }

        #endregion
    }
}