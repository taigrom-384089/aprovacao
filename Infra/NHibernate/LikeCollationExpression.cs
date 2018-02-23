using NHibernate;
using NHibernate.Criterion;
using NHibernate.SqlCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.NHibernate
{
    public class LikeCollationExpression : LikeExpression
    {
        const string CollationDefinition = " COLLATE {0} ";
        const string Latin_CI_AI = "LATIN1_GENERAL_CI_AI";

        // just a set of constructors
        public LikeCollationExpression(string propertyName, string value, char? escapeChar, bool ignoreCase) : base(propertyName, value, escapeChar, ignoreCase) { }
        public LikeCollationExpression(IProjection projection, string value, MatchMode matchMode) : base(projection, value, matchMode) { }
        public LikeCollationExpression(string propertyName, string value) : base(propertyName, value) { }
        public LikeCollationExpression(string propertyName, string value, MatchMode matchMode) : base(propertyName, value, matchMode) { }
        public LikeCollationExpression(string propertyName, string value, MatchMode matchMode, char? escapeChar, bool ignoreCase) : base(propertyName, value, matchMode, escapeChar, ignoreCase) { }

        // here we call the base and append the COLLATE
        public override SqlString ToSqlString(ICriteria criteria, ICriteriaQuery criteriaQuery, IDictionary<string, IFilter> enabledFilters)
        {
            // base LIKE
            var result = base.ToSqlString(criteria, criteriaQuery, enabledFilters);

            var sqlStringBuilder = new SqlStringBuilder(result);

            // extend it with collate
            sqlStringBuilder.Add(string.Format(CollationDefinition, Latin_CI_AI));

            return sqlStringBuilder.ToSqlString();
        }
    }
}
