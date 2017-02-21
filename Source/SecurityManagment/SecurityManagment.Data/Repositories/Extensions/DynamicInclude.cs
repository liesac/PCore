
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Data.Entity.Core.Objects;

public static class ObjectQueryExtensions
{

    public static IQueryable<T> Where<T>(this IQueryable<T> source, string predicate, params object[] values)
    {
        return  (IQueryable<T>)DynamicQueryable.Where((IQueryable)source, predicate, values);
    }

    public static IQueryable<T> Include<T>(this IQueryable<T> query, string[] includes)
    {
        List<IQueryable<T>> queryInclude = new List<IQueryable<T>>();
        
        for (int i = 0; i < includes.Length; i++)
        {
            if (i == 0)
            {
                queryInclude.Add((IQueryable<T>)query.GetType().GetMethod("Include").Invoke(query, new object[] { includes[i] }));
            }
            else
            {
                queryInclude.Add((IQueryable<T>)query.GetType().GetMethod("Include").Invoke(queryInclude[i - 1], new object[] { includes[i] }));
            }
        }

        if (queryInclude.Count > 0)
        {
            query = queryInclude[queryInclude.Count - 1];
            queryInclude.Clear();
        }

        return query;
    }

    public static ObjectQuery<T> Include<T>(this ObjectQuery<T> query, Expression<Func<T, object>> selector)
    {

        string propertyName = GetPropertyName(selector);

        return query.Include(propertyName);

    }

    private static string GetPropertyName<T>(Expression<Func<T, object>> expression)
    {

        MemberExpression memberExpr = expression.Body as MemberExpression;

        if (memberExpr == null)

            throw new ArgumentException("Expression body must be a member expression");

        return memberExpr.Member.Name;

    }
}


