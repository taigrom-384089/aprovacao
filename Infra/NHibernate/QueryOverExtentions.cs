using NHibernate;
using NHibernate.Criterion;
using NHibernate.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infra.NHibernate
{
    public static class QueryOverExtentions
    {
        // here: WhereLikeCiAi() 
        public static IQueryOver<TRoot, TSubType> WhereLikeCiAi<TRoot, TSubType>(
            this IQueryOver<TRoot, TSubType> query
            , Expression<Func<TSubType, object>> expression
            , string value
            , MatchMode matchMode)
        {
            var name = ExpressionProcessor.FindMemberExpression(expression.Body);
            query
                .UnderlyingCriteria
                .Add
                (
                    new LikeCollationExpression(name, value, matchMode)
                );
            return query;
        }
    }
}
