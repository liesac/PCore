using SecurityManagment.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SecurityManagment.Common.Utilities
{
    public static class UtilitiesObject
    {
        public static object RemoveOtherObjects<T>(List<T> listDtoObject) where T : BaseDto
        {
            foreach (object item in listDtoObject)
            {
                PropertyInfo[] properties = item.GetType().GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    if (!IsGenericType(property.PropertyType))
                    {
                        property.SetValue(item, null, null);
                    }
                }
            }

            return listDtoObject;
        }

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
    }
}
