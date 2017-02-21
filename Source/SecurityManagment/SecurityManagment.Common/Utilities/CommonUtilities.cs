using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityManagment.Common.Utilities
{
    public static class CommonUtilities
    {
        /// <summary>
        /// Gets the last day of.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        /// <author>Mauricio Suárez Robelto</author>
        public static DateTime GetLastDayOf(DateTime date)
        {
            return new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
        }

        public static string FormatDoublePrice(double? value, int numberDecimal = 0)
        {
            string decimalFormat = "";
            if (numberDecimal > 0)
            {
                decimalFormat = "." + string.Join("", Enumerable.Repeat("0", numberDecimal));
            }

            return string.Format("{0:###,###,###,##0" + decimalFormat + "}", value);
        }

        public static string GetJoinStringByCharacter(List<string> listString, string lastLabel = "", string character = ",")
        {
            return String.Join(character, listString.Where(x => x != "" && x != null).Select(x => x.ToString() + lastLabel).ToArray());
        }

        public static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        public static string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }

        /*public static List<GenericDataDto> GetParameterByUrl(string url)
        {
            List<GenericDataDto> listGenericDataDto = new List<GenericDataDto>();

            if (url.Split('?').Count() > 1)
            {
                string parametersUrl = url.Split('?')[1];

                for (int i = 0; i < parametersUrl.Split('&').Count() ; i++)
                {
                    string parameter = parametersUrl.Split('&')[i];
                    GenericDataDto dtoGenericData = new GenericDataDto();
                    dtoGenericData.Id = parameter.Split('=')[0];
                    dtoGenericData.Value = parameter.Split('=')[1];
                    listGenericDataDto.Add(dtoGenericData);
                }
            }

            return listGenericDataDto;
        }*/

    }
}
