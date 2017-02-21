using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Core.Objects;
using System.Linq.Expressions;

namespace SecurityManagment.Data.Repositories
{
    /// <summary>
    /// Base class for all the repositories.
    /// </summary>
    public abstract class BaseRepository<TObjectContext> where TObjectContext : ObjectContext
    {
        /// <summary>
        /// Builds the contains expression.
        /// </summary>
        /// <typeparam name="TElement">The type of the element.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="valueSelector">The value selector.</param>
        /// <param name="values">The values.</param>
        /// <returns>The Expression</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Expression<Func<TElement, bool>> BuildContainsExpression<TElement, TValue>(
             Expression<Func<TElement, TValue>> valueSelector, IEnumerable<TValue> values)
        {
            if (null == valueSelector)
            {
                throw new ArgumentNullException("valueSelector");
            }

            if (null == values)
            {
                throw new ArgumentNullException("values");
            }

            ParameterExpression p = valueSelector.Parameters.Single();
            if (!values.Any())
            {
                return e => false;
            }

            var equals = values.Select(value => (Expression)Expression.Equal(valueSelector.Body, Expression.Constant(value, typeof(TValue))));
            var body = equals.Aggregate<Expression>((accumulate, equal) => Expression.Or(accumulate, equal));
            return Expression.Lambda<Func<TElement, bool>>(body, p);
        }

        /// <summary>
        /// Builds the Not contains expression.
        /// </summary>
        /// <typeparam name="TElement">The type of the element.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="valueSelector">The value selector.</param>
        /// <param name="values">The values.</param>
        /// <author>Wbert Adrián Castro Vera</author>
        /// <returns>The not contains expression</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static Expression<Func<TElement, bool>> BuildNotContainsExpression<TElement, TValue>(
             Expression<Func<TElement, TValue>> valueSelector, IEnumerable<TValue> values)
        {
            if (null == valueSelector)
            {
                throw new ArgumentNullException("valueSelector");
            }

            if (null == values)
            {
                throw new ArgumentNullException("values");
            }

            ParameterExpression p = valueSelector.Parameters.Single();
            if (!values.Any())
            {
                return e => true;
            }

            var equals = values.Select(value => (Expression)Expression.NotEqual(valueSelector.Body, Expression.Constant(value, typeof(TValue))));
            var body = equals.Aggregate<Expression>((accumulate, equal) => Expression.And(accumulate, equal));
            return Expression.Lambda<Func<TElement, bool>>(body, p);
        }


        /// <summary>
        /// Returns the database context
        /// </summary>
        /// <returns>
        /// Database context.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// If the object isn't configured in the spring context an ArgumentException will be throw.
        /// </exception>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public virtual TObjectContext GetDataBaseContext()
        {
            throw new ArgumentException("GetDataBaseContext must be overrride.");
        }
    }
}
