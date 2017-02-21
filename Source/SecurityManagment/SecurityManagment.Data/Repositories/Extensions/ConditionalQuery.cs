namespace Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection;
    using System;
    using System.Collections;
    using System.Text.RegularExpressions;
    using System.Data.Entity.Validation;
    using LinqKit;
    using System.Linq.Expressions;
    using System.Data.Entity.Core.Objects;
    using SecurityManagment.Common.Dto;

    /// <summary>
    /// ConditionalQuery
    /// </summary>
    /// <author>Mauricio Suárez Robelto</author>
    /// <date>04/09/2012 10:39 p.m.</date>
    public class ConditionalQuery
    {
        #region  ValidationException

        public static DbEntityValidationException GetValidationException(DbEntityValidationException devex)
        {
            IEnumerable<DbEntityValidationResult> t = devex.EntityValidationErrors;

                        // Retrieve the error messages as a list of strings. 
                        IEnumerable <string> errorMessages = devex.EntityValidationErrors
                            .SelectMany(x => x.ValidationErrors)
                            .Select(x => x.ErrorMessage);

                        // Join the list to a single string. 
                        string fullErrorMessage = string.Join("; ", errorMessages);
                        
                        // Combine the original exception message with the new one. 
                        var exceptionMessage = string.Concat(devex.Message, " The validation errors are: ",fullErrorMessage);
                        
                        // Throw a new DbEntityValidationException with the improved exception message. 
                        return new System.Data.Entity.Validation.DbEntityValidationException(exceptionMessage,devex.EntityValidationErrors);
        }

        #endregion

        /// <summary>
        /// Generates the conditional query.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listDtoObject">The list dto object.</param>
        /// <returns></returns>
        /// <author>Mauricio Suárez Robelto</author>

        #region  ConditionalQuery
        public static Expression<Func<U, bool>> GeneratePredicateQuery<U, T>(List<T> listDtoObject) where T : BaseDto
        {
            var predicate = PredicateBuilder.False<U>();

            if (listDtoObject.Count() > 0)
            {
                string referenceWildcard = "ReferenceTable";
                int lenghtReferenceWildcard = referenceWildcard.Length;
                string typeWildcard = "System.Nullable`1[System.Boolean]";

                PropertyInfo[] properties = listDtoObject[0].GetType().GetProperties();

                int CurrentObject = 0;

                foreach (object item in listDtoObject)
                {
                    CurrentObject++;
                    
                    var predicateNew = PredicateBuilder.True<U>();

                    foreach (PropertyInfo property in properties)
                    {
                        if (ConditionalQuery.IsGenericType(property.PropertyType))
                        {
                            if (property.GetValue(item, null) != null)
                            {
                                bool resultIsFilter = true;
                                if (property.PropertyType.ToString() == typeWildcard)
                                {
                                    string validateFilter = property.Name;
                                    if ((validateFilter.Substring(0, validateFilter.Length < lenghtReferenceWildcard ? validateFilter.Length : lenghtReferenceWildcard)) == referenceWildcard)
                                    {
                                        resultIsFilter = false;
                                    }
                                }

                                if (resultIsFilter)
                                {
                                   ParameterExpression carParam = Expression.Parameter(typeof(U));
     
                                    Expression aLeft = Expression.PropertyOrField(carParam, property.Name);
                                    Expression aRight = Expression.Constant( property.GetValue(item, null));
                                    Expression makeEqualsPredicate = Expression.Equal(aLeft, aRight);
 
                                    Expression<Func<U, bool>> predicate1 = Expression.Lambda<Func<U, bool>>(makeEqualsPredicate, carParam);
                                    predicateNew = predicateNew.And(predicate1);
                                }
                            }
                        }
                    }

                    predicateNew.Compile();
                    predicate = predicate.Or(predicateNew.Expand());
                }
            }

            predicate.Compile();

            return predicate;
        }

        /// <summary>
        /// Generates the conditional query.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listDtoObject">The list dto object.</param>
        /// <returns></returns>
        /// <author>Mauricio Suárez Robelto</author>
        public static string GenerateConditionalQuery<T>(List<T> listDtoObject) where T : BaseDto
        {

            if (listDtoObject.Count() > 0)
            {
                string referenceWildcard = "ReferenceTable";
                int lenghtReferenceWildcard = referenceWildcard.Length;
                string typeWildcard = "System.Nullable`1[System.Boolean]";

                StringBuilder sbResult = new StringBuilder();
                StringBuilder sb = new StringBuilder();

                PropertyInfo[] properties = listDtoObject[0].GetType().GetProperties();

                int CurrentObject = 0;
                foreach (object item in listDtoObject)
                {
                    CurrentObject++;

                    int i = 1;
                    foreach (PropertyInfo property in properties)
                    {
                        if (ConditionalQuery.IsGenericType(property.PropertyType))
                        {
                            if (property.GetValue(item, null) != null)
                            {
                                bool resultIsFilter = true;
                                if (property.PropertyType.ToString() == typeWildcard)
                                {
                                    string validateFilter = property.Name;
                                    if ((validateFilter.Substring(0, validateFilter.Length < lenghtReferenceWildcard ? validateFilter.Length : lenghtReferenceWildcard)) == referenceWildcard)
                                    {
                                        resultIsFilter = false;
                                    }
                                }

                                if (resultIsFilter)
                                {
                                    string validate = property.PropertyType.ToString();
                                    if (validate == "System.Nullable`1[System.DateTime]")
                                    {
                                        sb.Append((i != 1 ? " AND (" : ""));
                                        sb.Append("it." + property.Name).Append(" >= ").Append(("@" + property.Name + "Ini" + CurrentObject.ToString()));
                                        sb.Append(" AND " + "it." + property.Name).Append(" <= ").Append(("@" + property.Name + "End" + CurrentObject.ToString()));
                                        sb.Append((i != 1 ? ")" : ""));
                                        i++;
                                    }
                                    else
                                    {
                                        sb.Append((i != 1 ? " AND " : ""));
                                        sb.Append("it." + property.Name).Append(" = ").Append(("@" + property.Name + CurrentObject.ToString()));
                                        i++;
                                    }

                                }
                            }
                        }
                    }

                    if (sb.Length > 0)
                    {
                        sb.Insert(0, "(");
                        sb.Insert(sb.Length, ")");
                    }

                    if (sbResult.Length > 0 && sb.Length > 0)
                    {
                        sbResult.Append(" OR ");
                    }
                    sbResult.Append(sb);
                    sb.Clear();
                }


                if (sbResult.Length == 0)
                {
                    sbResult.Append("1 = 1");
                }

                return sbResult.ToString();
            }
            else
            {
                return "1 = 1";
            }
        }

        /// <summary>
        /// Generates the parameters conditional query.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listDtoObject">The list dto object.</param>
        /// <returns></returns>
        /// <author>Mauricio Suárez Robelto</author>
        public static ObjectParameter[] GenerateParametersConditionalQuery<T>(List<T> listDtoObject) where T : BaseDto
        {
            List<ObjectParameter> parameters = new List<ObjectParameter>();

            if (listDtoObject.Count() > 0)
            {
                PropertyInfo[] properties = listDtoObject[0].GetType().GetProperties();
                int CurrentObject = 0;

                foreach (object item in listDtoObject)
                {
                    CurrentObject++;
                    foreach (PropertyInfo property in properties)
                    {
                        if (ConditionalQuery.IsGenericType(property.PropertyType))
                        {
                            if (property.GetValue(item, null) != null)
                            {
                                string validate = property.PropertyType.ToString();
                                if (validate == "System.Nullable`1[System.DateTime]")
                                {
                                    DateTime filterDate = (DateTime)property.GetValue(item, null);
                                    parameters.Add(new ObjectParameter(property.Name + "Ini" + CurrentObject.ToString(), new DateTime(filterDate.Year, filterDate.Month, filterDate.Day, 0, 0, 0)));
                                    parameters.Add(new ObjectParameter(property.Name + "End" + CurrentObject.ToString(), new DateTime(filterDate.Year, filterDate.Month, filterDate.Day, 23, 59, 59)));
                                }
                                else
                                {
                                    parameters.Add(new ObjectParameter(property.Name + CurrentObject.ToString(), property.GetValue(item, null)));
                                }
                            }
                        }
                    }
                }
            }

            return parameters.ToArray();
        }

        /// <summary>
        /// Determines whether [is generic type] [the specified property type].
        /// </summary>
        /// <param name="propertyType">Type of the property.</param>
        /// <returns>
        ///   <c>true</c> if [is generic type] [the specified property type]; otherwise, <c>false</c>.
        /// </returns>
        /// <author>Mauricio Suárez Robelto</author>
        public static bool IsGenericType(Type propertyType)
        {
            bool result = true;
            string validate = propertyType.ToString();

            string PatronBusqueda = "List|Dto";
            Regex regex = new Regex(PatronBusqueda, RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);

            if (regex.IsMatch(validate))
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Validates the primary key value in dto.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listDtoObject">The list dto object.</param>
        /// <param name="entitytest1TableKeys">The entitytest1 table keys.</param>
        /// <returns></returns>
        /// <author>Mauricio Suárez Robelto</author>
        public static bool[] ValidatePrimaryKeyValueInDto<T>(List<T> listDtoObject, string[] entitytest1TableKeys) where T : BaseDto
        {
            List<bool> parameters = new List<bool>();
            int entitytest1TableKeysCount = entitytest1TableKeys.Count();
            int dtotest1TableKeysCountInValue = 0;

            if (listDtoObject.Count() > 0 && entitytest1TableKeysCount > 0)
            {
                PropertyInfo[] properties = listDtoObject[0].GetType().GetProperties();

                foreach (object item in listDtoObject)
                {
                    dtotest1TableKeysCountInValue = 0;

                    foreach (PropertyInfo property in properties)
                    {
                        bool resultPropertyIsKey = ConditionalQuery.ValidatePropertyIsKey(property.Name, entitytest1TableKeys);

                        if (resultPropertyIsKey)
                        {
                            if (property.GetValue(item, null) != null)
                            {
                                dtotest1TableKeysCountInValue++;
                            }
                        }
                    }

                    if (dtotest1TableKeysCountInValue == entitytest1TableKeysCount)
                    {
                        parameters.Add(true);
                    }
                    else
                    {
                        if (dtotest1TableKeysCountInValue > 0)
                        {
                            throw new Exception("Not enough information about the table keys to make a decision. A key must be missing.");
                        }
                        else
                        {
                            parameters.Add(false);
                        }
                    }
                }
            }

            return parameters.ToArray();
        }

        /// <summary>
        /// Validates the property is key.
        /// </summary>
        /// <param name="propertyNameDto">The property name dto.</param>
        /// <param name="entitytest1TableKeys">The entitytest1 table keys.</param>
        /// <returns></returns>
        /// <author>Mauricio Suárez Robelto</author>
        private static bool ValidatePropertyIsKey(string propertyNameDto, string[] entitytest1TableKeys)
        {
            bool result = false;
            foreach (string entityKeyName in entitytest1TableKeys)
            {
                if (entityKeyName == propertyNameDto)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        #endregion

        #region  ConditionalQueryInclude

        /// <summary>
        /// Generates the includes.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listDtoObject">The list dto object.</param>
        /// <returns></returns>
        /// <author>Mauricio Suárez Robelto</author>
        public static string[] GenerateIncludes<T>(List<T> listDtoObject) where T : BaseDto
        {
            string referenceWildcard = "ReferenceTable";
            int lenghtReferenceWildcard = referenceWildcard.Length;
            string typeWildcard = "System.Nullable`1[System.Boolean]";


            List<string> includes = new List<string>();

            if (listDtoObject.Count() > 0)
            {
                PropertyInfo[] properties = listDtoObject[0].GetType().GetProperties();
                object item = listDtoObject[0];
                ConditionalQuery.ValidateIncludes(item, includes, typeWildcard, "");
            }

            for (int i = 0; i < includes.Count; i++)
            {
                if (includes[i].Length > lenghtReferenceWildcard)
                {
                    if (referenceWildcard == includes[i].Substring(includes[i].IndexOf('.') + 1, lenghtReferenceWildcard))
                    {
                        includes[i] = includes[i].Replace(referenceWildcard, "").Replace("Dto", "");
                        includes[i] = (includes[i].StartsWith(".") ? includes[i].Replace(".", "") : includes[i]);
                    }
                    else
                    {
                        includes[i] = null;
                    }
                }
                else
                {
                    includes[i] = null;
                }
            }

            includes.RemoveAll(remove => remove == null);

            //return ConditionalQuery.ConcatIncludes(includes).ToArray();
            return ConditionalQuery.GenerateNewInclude(includes).ToArray();
        }

        /// <summary>
        /// Validates the includes.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="includes">The includes.</param>
        /// <param name="typeWildcard">The type wildcard.</param>
        /// <param name="parentTable">The parent table.</param>
        /// <author>Mauricio Suárez Robelto</author>
        public static void ValidateIncludes(object item, List<string> includes, string typeWildcard, string parentTable)
        {
            if (item != null)
            {
                PropertyInfo[] properties = item.GetType().GetProperties();

                foreach (PropertyInfo property in properties)
                {
                    if (property.GetValue(item, null) != null)
                    {
                        if (ConditionalQuery.IsGenericType(property.PropertyType))
                        {
                            if (property.PropertyType.ToString() == typeWildcard)
                            {
                                bool? valueProperty = (bool?)property.GetValue(item, null);

                                if (valueProperty.Value)
                                {
                                    includes.Add(parentTable + "." + property.Name);
                                }
                            }
                        }
                        else
                        {
                            if (property.PropertyType.IsGenericType)
                            {
                                IList listNewObject = (IList)property.GetValue(item, null);

                                if (listNewObject.Count > 0)
                                {
                                    ConditionalQuery.ValidateIncludes(listNewObject[0], includes, typeWildcard, listNewObject[0].GetType().Name);
                                }
                            }
                            else
                            {
                                ConditionalQuery.ValidateIncludes(property.GetValue(item, null), includes, typeWildcard, property.GetValue(item, null).GetType().Name);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Generates the new include.
        /// </summary>
        /// <param name="listInclude">The list include.</param>
        /// <returns></returns>
        /// <author>Mauricio Suárez Robelto</author>
        public static List<string> GenerateNewInclude(List<string> listInclude)
        {
            return ConditionalQuery.GenerateTree(ConditionalQuery.RemoveMatches(ConditionalQuery.UnionString(listInclude), listInclude));
        }

        /// <summary>
        /// Generates the tree.
        /// </summary>
        /// <param name="listInclude">The list include.</param>
        /// <returns></returns>
        /// <author>Mauricio Suárez Robelto</author>
        /// <date>04/09/2012 10:35 p.m.</date>
        public static List<string> GenerateTree(List<string> listInclude)
        {
            List<string> listTreeInclude = new List<string>();

            List<List<string>> listIncludesSplitted = new List<List<string>>();

            listInclude.ForEach(include =>
            {
                listIncludesSplitted.Add(include.Split('.').ToList());
            });

            foreach (List<string> items in listIncludesSplitted)
            {
                string concat = null;
                int i = 0;

                foreach (string item in items)
                {
                    concat = concat + (i > 0 ? "." : "") + item;
                    if (listTreeInclude.Where(filter => filter == concat).Count() == 0)
                    {
                        listTreeInclude.Add(concat);
                    }
                    i++;
                }
            }

            return listTreeInclude;
        }

        /// <summary>
        /// Removes the matches.
        /// </summary>
        /// <param name="listUnionString">The list union string.</param>
        /// <param name="listInclude">The list include.</param>
        /// <returns></returns>
        /// <author>Mauricio Suárez Robelto</author>
        public static List<string> RemoveMatches(List<string> listUnionString, List<string> listInclude)
        {
            List<string> verifiUnionstring = new List<string>();

            for (int ij = 0; ij < listUnionString.Count; ij++)
            {
                string[] valueIni = listUnionString[ij].Split('.');
                for (int j = 0; j < listUnionString.Count; j++)
                {
                    string[] valueEnd = listUnionString[j].Split('.');
                    if (valueEnd.Count() == 3)
                    {
                        if (valueIni[1] + "." + valueIni[2] == valueEnd[0] + "." + valueEnd[1])
                        {
                            listUnionString[ij] = valueIni[0] + "." + valueIni[1] + "." + valueIni[2] + "." + valueEnd[2];
                            listUnionString[j] = "";
                        }
                    }
                }
            }

            listUnionString.RemoveAll(filter => filter == "");

            List<int> listRemoveIndex = new List<int>();

            int i = 0;

            foreach (string include in listInclude)
            {
                foreach (string unionString in listUnionString)
                {
                    string PatronBusqueda = include;
                    Regex regex = new Regex(PatronBusqueda, RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);

                    if (regex.IsMatch(unionString))
                    {
                        if (ConditionalQuery.ValidateStringExist(PatronBusqueda.Split('.').ToList(),unionString.Split('.').ToList()) && listRemoveIndex.Where(filter => filter == i).Count() == 0)
                        {
                            listRemoveIndex.Add(i);
                        }
                    }
                }

                i++;
            }

            listRemoveIndex.ForEach(data => { listInclude[data] = "Delete"; });
            listInclude.RemoveAll(filter => filter == "Delete");
            listUnionString.AddRange(listInclude);


            //listRemoveIndex.Clear();
            List<string> listnew = new List<string>();
            listUnionString.ForEach(data => {
                string result = data;
                string[] element=  data.Split('.');
                Regex regex = new Regex(element[0], RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);

                foreach (var item in listUnionString.Where(filters => filters != data))
                {
                    if (regex.IsMatch(item))
                    {
                        int index = item.IndexOf(element[0]);
                        if (ConditionalQuery.ValidateStringExist(new List<string> {element[0]},item.Split('.').ToList()) &&  index > 0)
                        {
                            result = item.Substring(0,index) + data;
                            break;
                        }
                    }
                }

                listnew.Add(result);
            });

            return listnew;
            //return listUnionString;
        }

        public static bool ValidateStringExist(List<string> stringSearch, List<string> stringBase)
        {
            bool exist = true;
            foreach (var item in stringSearch)
            {
                if (stringBase.Where(filter => filter == item).Count() == 0)
                {
                    exist = false;
                    break;
                }
            }

            return exist;
        }

        /// <summary>
        /// Unions the string.
        /// </summary>
        /// <param name="listInclude">The list include.</param>
        /// <returns></returns>
        /// <author>Mauricio Suárez Robelto</author>
        public static List<string> UnionString(List<string> listInclude)
        {
            List<List<string>> listIncludesSplitted = new List<List<string>>();

            listInclude.ForEach(include =>
            {
                listIncludesSplitted.Add(include.Split('.').ToList());
            });

            List<string> listUnionString = new List<string>();

            foreach (List<string> listValidate in listIncludesSplitted)
            {
                if (listValidate.Count == 2)
                {
                    foreach (List<string> listSource in listIncludesSplitted)
                    {
                        if (listSource.Count == 2 && listValidate[1] == listSource[0])
                        {
                            listUnionString.Add(listValidate[0] + "." + listValidate[1] + "." + listSource[1]);
                        }
                    }
                }
            }

            return listUnionString;
        }

        #endregion
    }
}
